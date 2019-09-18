using AppImagensTeste.Domain.Util.Enum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppImagensTeste.Domain.Util.Interface
{
    public interface IImageManipulator
    {
        Image Resize(Image image, int width, int height, ImageProportionsTransform imageProportionsTransform = ImageProportionsTransform.Fit);

        Image Crop(
            Image originalImage,
            int width,
            int height,
            ImageCropPosition proportionsTransform = ImageCropPosition.Center,
            int initialX = 0,
            int initialY = 0
        );
    }
}
