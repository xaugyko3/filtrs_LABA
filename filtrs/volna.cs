using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filtrs
{
    class volna : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color resultColor;
            x = Clamp((int)(x + 20 * System.Math.Sin((2 * System.Math.PI * x) / 30)), 0 , sourceImage.Width - 1);
            Color newcolor = sourceImage.GetPixel(x, y);
            resultColor = newcolor;
            return resultColor;
        }
    }
}
