using AppImagensTeste.Domain.Entity;
using AppImagensTeste.Domain.Util.Interface;
using AppImagensTeste.Infra.Repositories.Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AppImagensTeste
{
    public partial class MainForm : Form
    {
        private IHttpFilesHelper _httpFilesHelper;
        private IImageManipulator _imageManipulator;
        private ICloudHelper _cloudHelper;

        public MainForm(
            IHttpFilesHelper _httpFilesHelper, 
            IImageManipulator _imageManipulator,
            ICloudHelper _iCloudHelper
        )
        {
            InitializeComponent();

            this._httpFilesHelper = _httpFilesHelper;
            this._imageManipulator = _imageManipulator;

            this._cloudHelper = _iCloudHelper;
            _iCloudHelper.Config("DefaultEndpointsProtocol=https;AccountName=cs2f2fa088b7edfx4579xb65;AccountKey=7pBk9brJlUj2mmDOyesFhPLkymjv2DGYSCvV8OH5DeKUBAnLihVDDqbIzyFgkRABhdo/xthfP5CfZfDhPlFc9Q==;EndpointSuffix=core.windows.net");
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            Run(this);
        }

        async static Task Run(MainForm form)
        {
            try
            {

                Int32 idPartner = form.GetSelectedPartner();
                List<Media> listMedias = new List<Media>();

                MediaRepository mediaRepo = new MediaRepository();
                FeedPosterLockRepository feedLockRepo = new FeedPosterLockRepository();
                FeedPosterRepository feedPosterRepo = new FeedPosterRepository();

                form.Log("Apagando os locks deste parceiro");
                feedLockRepo.RemoveAll(idPartner);

                foreach (String strId in form.txtList.Text.Split(','))
                {
                    Int32 id = Int32.Parse(strId);
                    Media item = mediaRepo.Get(id);
                    listMedias.Add(item);
                }

                form.Log("Lista de Midias formada para subir as respectivas imagens...");
                form.progress.Minimum = 0;
                form.progress.Maximum = listMedias.Count;
                form.progress.Step = 0;
                int step = 0;

                int requiredWidth = 350;
                int requiredHeight = 530;

                foreach (Media media in listMedias)
                {
                    try
                    {
                        form.Log("Verificar se já existe uma imagem com as dimensoes e esta midia");
                        FeedPoster feedPoster = feedPosterRepo.GetByMediaId(media.Id, requiredWidth, requiredHeight);

                        if (feedPoster == null)
                        {
                            form.Log("A imagem NÃO existe, subindo...");

                            // path 
                            String[] pathParts = media.PosterURL.Split('/');
                            String folderPath = pathParts[pathParts.Length - 2];
                            String filePath = pathParts[pathParts.Length - 1];
                            String extension = filePath.Split('.')[1];
                            String destinyPath = $"{folderPath}/{media.MediaId}_feed_{requiredWidth}_{requiredHeight}.{extension}";

                            form.Log($"Irá salvar em: {destinyPath}. ");

                            // resizing
                            Image originalImage = form._httpFilesHelper.GetImage(media.PosterURL);
                            Image imageResized = form._imageManipulator.Resize(originalImage, requiredWidth, requiredHeight);
                            Image imageCropped = form._imageManipulator.Crop(imageResized, requiredWidth, requiredHeight);

                            form.Log($"Imagem redimensionada. Subindo... ");

                            // Image to stream
                            var stream = new System.IO.MemoryStream();
                            imageCropped.Save(stream, ImageFormat.Jpeg);
                            // send to storage
                            String pathUpload = form._cloudHelper.sendToStorage(stream, $"{destinyPath}");

                            form.Log($"Strorage OK: {pathUpload} ");

                            feedPoster = feedPosterRepo.Save(new FeedPoster()
                            {
                                MediaId = media.Id,
                                Url = pathUpload,
                                Height = requiredHeight,
                                Width = requiredWidth
                            }
                            );

                            form.Log($"Novo FeedPoster criado #{feedPoster.Id}");

                        }
                        else
                        {
                            form.Log("A imagem existe, apenas criar um lock para ela");
                            form.Log($"Imagem: #{feedPoster.Id}: {feedPoster.Url}");
                        }

                        form.Log("Criando um lock para este...");
                        FeedPosterLock feedPosterLock = feedLockRepo.Save(new FeedPosterLock()
                        {
                            IdFeedPoster = feedPoster.Id,
                            IdFeedPosterPartner = idPartner
                        });
                        form.Log($"Lock criado #{feedPosterLock}...");
                        form.Log($"ok... {++step}/{form.progress.Maximum}");

                        form.progress.PerformStep();
                    }
                    catch (Exception ex)
                    {
                        form.Log($"* EXCPETION: {ex.Message}");
                    }
                }

                // excluding
                form.Log("Excluindo imagens sem lock");
                List<FeedPoster> listPostersUnlockeds = feedPosterRepo.GetAllUnlocked();
                foreach(FeedPoster feedPoster in listPostersUnlockeds)
                {
                    String[] pathParts = feedPoster.Url.Split('/');
                    String folderPath = pathParts[pathParts.Length - 2];
                    String filePath = pathParts[pathParts.Length - 1];
                    String extension = filePath.Split('.')[1];

                    String path = $"{folderPath}/{filePath}";
                    form._cloudHelper.Remove(path);
                    feedPosterRepo.Remove(feedPoster);
                    form.Log($"Poster excluido... #{feedPoster.Id} => {feedPoster.Url}");
                }

                form.Log("Todos os posters sem lock excluidos");

            }
            catch (Exception ex)
            {
                form.ErrorsTreatment(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                cboPartner.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                this.ErrorsTreatment(ex.Message);
            }
        }

        private Int32 GetSelectedPartner()
        {
            switch (cboPartner.SelectedItem.ToString())
            {
                case "TCL":
                    return 1;
                case "Samsung":
                    return 2;
                default:
                    return 1;
            }
        }

        private void ErrorsTreatment(String errorMessage)
        {
            MessageBox.Show(errorMessage);
        }

        private void Log(String log)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(Log), new object[] { log });
                return;
            }
            txtLog.Text = log + Environment.NewLine + Environment.NewLine + txtLog.Text;
            txtLog.ScrollToCaret();
        }

    }
}
