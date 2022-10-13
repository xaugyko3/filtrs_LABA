using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filtrs
{
    class MatMorf
    {
        public static int[,] stuctElemnt = new int[,] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
        int[,] imageWithZeroaNull;
        public MatMorf(Bitmap sourceImage)
        {
            imageWithZeroaNull = new int[sourceImage.Width, sourceImage.Height];
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            // реализуем перевод в бинарное изображение
            for (int i = 0; i < sourceImage.Width; i++)
            {

                for (int j = 0; j < sourceImage.Height; j++)
                {
                    if (sourceImage.GetPixel(i, j).R != 255 || sourceImage.GetPixel(i, j).G != 255 || sourceImage.GetPixel(i, j).B != 255)
                        imageWithZeroaNull[i, j] = 1;
                    else
                        imageWithZeroaNull[i, j] = 0;
                }
            }
        }
        public Bitmap dilation(Bitmap sourceImage)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    if (imageWithZeroaNull[i, j] == 1)
                    {
                        for (int k = -1; k < 1; k++)
                        {
                            for (int l = -1; l < 1; l++)
                            {
                                // imageWithZeroaNull[i + l, j + l] = 1;
                                if (i+k < sourceImage.Width-1&&i +k >0)
                                {
                                    resultImage.SetPixel(i + k, j , Color.FromArgb(255, 0, 0, 0)); 
                                    
                                }
                                if (j+l < sourceImage.Height-1 && j + l > 0)
                                {
                                    resultImage.SetPixel(i, j+l, Color.FromArgb(255, 0, 0, 0));
                                }
                               
                            }
                        }
                    }
                    else
                    {
                        resultImage.SetPixel(i, j, Color.FromArgb(255, 255, 255, 255));
                    }
                }
            }
            //resultImage.SetPixel(i, j, Color.FromArgb(255, 0, 0, 0));
            return resultImage;
        }
    }
}
