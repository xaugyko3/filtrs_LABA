using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filtrs
{
    class bright : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int b = 100;
            int min = 0;
            int max = 255;
            Color sourceColor = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(Clamp(sourceColor.R + b , min , max),
                                               Clamp(sourceColor.G + b, min, max),
                                               Clamp(sourceColor.B + b, min ,max));
            return resultColor;

        }
    }
}
