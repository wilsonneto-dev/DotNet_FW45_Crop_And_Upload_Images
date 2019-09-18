using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AppImagensTeste.Domain.Util.Interface
{
    class WebClientHttpFilesHelper : IHttpFilesHelper
    {
        public Image GetImage(String imageUrl)
        {
            WebClient webClient = new WebClient();
            byte[] imageBytes = webClient.DownloadData(imageUrl);
            MemoryStream imageStream = new MemoryStream(imageBytes);
            Image OriginalImage = Image.FromStream(imageStream);
            return OriginalImage;
        }

        public String DownloadImage(String imageUrl, String savePath = "", Boolean relativePath = true)
        {
            Image image = this.GetImage(imageUrl);

            if(relativePath == true)
                savePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, savePath);

            image.Save(savePath);

            return savePath;
        }
    }
}
