using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppImagensTeste.Domain.Util.Interface
{
    public interface IHttpFilesHelper
    {
        Image GetImage(String imageUrl);

        String DownloadImage(String imageUrl, String path, bool relativePath = true);
    }
}
