using AppImagensTeste.Domain.Util.Enum;
using AppImagensTeste.Domain.Util.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppImagensTeste.Domain.Util
{
    class GenericImageManipulator : IImageManipulator
    {
        public Image Resize(Image originalImage, int width, int height, ImageProportionsTransform proportionsTransform = ImageProportionsTransform.Fit)
        {
            // calc the proportional resize
            int futureWidth = width, 
                futureHeight = height;

            if (proportionsTransform == ImageProportionsTransform.Fit)
            {
                Decimal growthIndex = 0;
                if(originalImage.Width > originalImage.Height)
                {
                    growthIndex = (Decimal)futureWidth / (Decimal)originalImage.Width;
                    futureHeight = (int)(originalImage.Height * growthIndex);
                }
                else
                {
                    growthIndex = (Decimal)futureHeight / (Decimal)originalImage.Height;
                    futureWidth = (int)(originalImage.Width * growthIndex);
                }
            }

            // resizing
            Bitmap blankBitmap = new Bitmap(futureWidth, futureHeight);
            blankBitmap.SetResolution(originalImage.HorizontalResolution, originalImage.VerticalResolution);
            Graphics graphic = Graphics.FromImage(blankBitmap);
            graphic.SmoothingMode = SmoothingMode.AntiAlias;
            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphic.DrawImage(originalImage, 0, 0, futureWidth, futureHeight);
            
            return (Image)blankBitmap;

        }

        public Image Crop(
            Image originalImage,
            int width,
            int height,
            ImageCropPosition proportionsTransform = ImageCropPosition.Center,
            int initialX = 0,
            int initialY = 0
        )
        {

            // Calc croppiong initial positions
            if(proportionsTransform == ImageCropPosition.Center)
            {
                if (width < originalImage.Width)
                    initialX = (originalImage.Width - width)/2;
                
                if (height < originalImage.Height)
                    initialY = (originalImage.Height - height)/2;

                // prevent error, when target crop is bigger than original image
                if (width > originalImage.Width) width = originalImage.Width;
                if (height > originalImage.Height) height = originalImage.Height;

            }

            // resizing
            Bitmap blankBitmap = new Bitmap(width, height);
            blankBitmap.SetResolution(originalImage.Width, originalImage.Height);
            Graphics graphic = Graphics.FromImage(blankBitmap);
            graphic.SmoothingMode = SmoothingMode.AntiAlias;
            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphic.DrawImage(originalImage, new Rectangle(0, 0, width, height), initialX, initialY, width, height, GraphicsUnit.Pixel);

            return (Image) blankBitmap;


        }
    }
}
