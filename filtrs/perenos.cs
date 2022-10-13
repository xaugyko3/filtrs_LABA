using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filtrs
{
    class perenos : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {


            int nextx = x + 50;
            Color resultColor;
            if (nextx < sourceImage.Width - 1)
            {
                Color neigghborColor = sourceImage.GetPixel(nextx, y);
                resultColor = Color.FromArgb(neigghborColor.R, neigghborColor.G, neigghborColor.B);
            }    
            else
            {
                resultColor = Color.FromArgb(0, 0 ,0 );

            }
            return resultColor;
                
        }
    }
}
