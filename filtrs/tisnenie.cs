using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace filtrs
{
    class tisnenie : Filters
    {
        public float[,] kernel = new float[3, 3];
        public tisnenie() { }
        public tisnenie(float[,] kernel)
        {
           
            this.kernel = kernel;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {

            kernel = new float[3, 3];
            kernel[0, 0] = 0;
            kernel[0, 1] = 1;
            kernel[0, 2] = 0;
            kernel[1, 0] = 1;
            kernel[1, 1] = 0;
            kernel[1, 2] = -1;
            kernel[2, 0] = 0;
            kernel[2, 1] = -1;
            kernel[2, 2] = 0;
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;

            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            float norm = 2;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    kernel[i, j] /= norm;
            for (int l = -radiusY; l <= radiusY; l++)
                for (int k = -radiusX; k <= radiusX; k++)// а как? где?
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neigghborColor = sourceImage.GetPixel(idX, idY);
                    resultR += neigghborColor.R * kernel[k + radiusX, l + radiusY];
                    resultG += neigghborColor.G * kernel[k + radiusX, l + radiusY];
                    resultB += neigghborColor.B * kernel[k + radiusX, l + radiusY];
                    //norm += kernel[k + radiusX, l + radiusY];
                }
           

            return Color.FromArgb(
                Clamp((int)resultR + 200 , 0, 255),
                Clamp((int)resultG + 200 , 0, 255),
                Clamp((int)resultB + 200 , 0, 255)
                );

        }
    }
    
}
