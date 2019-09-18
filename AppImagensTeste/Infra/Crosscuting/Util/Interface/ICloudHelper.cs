using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppImagensTeste.Domain.Util.Interface
{
    public interface ICloudHelper
    {
        void Config(String connectionString);

        String sendToStorage(string localFile, string storageFile, string container = "cov");
        String sendToStorage(Stream stream, string storageFile, string container = "cov");

        Boolean Remove(String path, string container = "cov");

    }
}
