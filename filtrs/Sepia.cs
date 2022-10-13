using filtrs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace filtrs
{
     class Sepia : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y )
        {

            Color sourceColor = sourceImage.GetPixel(x, y);
            int intencety = (int)((float)(0.36 * sourceColor.R + 0.53 * sourceColor.G + 0.11 * sourceColor.B));
            int k = 30; // если меньше то чб
            int min = 0;
            int max = 255;
            //int red1 = intencety + 2 * k;
           // int green1 = intencety + 1 * k; // ТУТ ДОЛЖНО БЫТЬ  0.5
            //int blue1 = intencety - 1 * k;
            //int  result_g, result_b;
            //result_r = Clamp(intencety + 2 * k, min ,max);
            //result_g = Clamp(green1, min, max);
            //result_b = Clamp(blue1, min, max);
            Color resultColor = Color.FromArgb( Clamp(intencety + 2 * k, min, max),
                                               Clamp(intencety + (int)((float) 0.5* k), min, max),
                                               Clamp(intencety -1* k, min, max)
                                             );
            return resultColor;
        }
    }
}
