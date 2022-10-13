using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace filtrs
{
    class povorot : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int centrx, centry, nextx, nexty;
            double angle = 190;
            Color resultColor;
            if (sourceImage.Width % 2 == 0)
            {
                centrx = sourceImage.Width / 2;
                if (sourceImage.Height % 2 == 0)
                {
                    centry = sourceImage.Height / 2;
                }
                else
                {
                    centry = sourceImage.Height / 2 + 1;
                }
            }
            else
            {
                centrx = sourceImage.Width / 2 + 1;
                if (sourceImage.Height % 2 == 0)
                {
                    centry = sourceImage.Height / 2;
                }
                else
                {
                    centry = sourceImage.Height / 2 + 1;
                }
            }
            nextx = (int)((x - centrx) * System.Math.Cos(angle) - (y - centry) * System.Math.Sin(angle) + centrx);
            nexty = (int)((x - centrx) * System.Math.Sin(angle) + (y - centry) * System.Math.Cos(angle) + centry);
            if ((nextx < sourceImage.Width - 1)&&(nextx > 0))
            {
                if ((nexty < sourceImage.Width - 1) && (nexty > 0))
                {
                    Color neigghborColor = sourceImage.GetPixel(nextx, nexty);
                    resultColor = Color.FromArgb(neigghborColor.R, neigghborColor.G, neigghborColor.B);
                }
                else
                {

                    resultColor = Color.FromArgb(0, 0, 0);

                }
            }
            else
            {
                resultColor = Color.FromArgb(0, 0, 0);

            }

            return resultColor;

        }
    }
}
