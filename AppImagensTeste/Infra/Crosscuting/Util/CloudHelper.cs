using AppImagensTeste.Domain.Util.Interface;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppImagensTeste.Domain.Util
{
    class CloudHelper : ICloudHelper
    {
        private String ConnectionString;
        public void Config(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public bool Remove(string path, string container = "cov")
        {
            CloudStorageAccount azureAccount = CloudStorageAccount.Parse(this.ConnectionString);
            CloudBlobClient cloudBlobClient = azureAccount.CreateCloudBlobClient();
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(container);
            CloudBlockBlob blockBlob = cloudBlobContainer.GetBlockBlobReference(path);
            return blockBlob.DeleteIfExists();
        }

        public String sendToStorage(string localFile, string storageFile, string container = "cov")
        {
            CloudStorageAccount azureAccount = CloudStorageAccount.Parse(this.ConnectionString);
            CloudBlobClient cloudBlobClient = azureAccount.CreateCloudBlobClient();
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(container);

            CloudBlockBlob blockBlob = cloudBlobContainer.GetBlockBlobReference(storageFile);
            blockBlob.Properties.ContentType = "image/jpg";

            using (var fileStream = System.IO.File.OpenRead(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, localFile)))
            {
                blockBlob.UploadFromStream(fileStream);
            }
            return blockBlob.Uri.ToString();
        }
        public String sendToStorage(Stream stream, string storageFile, string container = "cov")
        {
            CloudStorageAccount azureAccount = CloudStorageAccount.Parse(this.ConnectionString);
            CloudBlobClient cloudBlobClient = azureAccount.CreateCloudBlobClient();
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(container);

            CloudBlockBlob blockBlob = cloudBlobContainer.GetBlockBlobReference(storageFile);
            blockBlob.Properties.ContentType = "image/jpg";
            stream.Seek(0, SeekOrigin.Begin);

            blockBlob.UploadFromStream(stream);
            return blockBlob.Uri.ToString();
        }
    }
}
