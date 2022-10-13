using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filtrs
{
     class DILATION 
    {
        public static int[,] stuctElemnt = new int[,] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
        int[,] imageWithZeroaNull;
       
        public Bitmap doBinary(Bitmap sourceImage)
        {
                Bitmap resultImage;
                imageWithZeroaNull = new int[sourceImage.Width, sourceImage.Height];
                resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
                // реализуем перевод в бинарное изображение
                for (int i = 0; i < sourceImage.Width; i++)
                {

                    for (int j = 0; j < sourceImage.Height; j++)
                    {
                        if (sourceImage.GetPixel(i, j).R != 255 || sourceImage.GetPixel(i, j).G != 255 || sourceImage.GetPixel(i, j).B != 255)
                            imageWithZeroaNull[i, j] = 1;
                        else
                            imageWithZeroaNull[i, j] = 0;

                    Console.WriteLine(imageWithZeroaNull[i, j]);
                    }
                }





            for (int i = 0; i < sourceImage.Width-2; i++)
             {
                 for (int j = 0; j < sourceImage.Height-2; j++)
                 {
                    if (imageWithZeroaNull[i, j] == 1)
                    {
                        resultImage.SetPixel(i, j, Color.White);
                        for (int k = -1; k < 1; k++)
                        {
                            int xcentr = 1;
                            int ycentr = 1;
                            for (int l = -1; l < 1; l++)
                            {
                                //imageWithZeroaNull[i + l, j + l] = 1;
                          
                                if (i + k < sourceImage.Width - 1 && i + k > 0)
                                {
                                    resultImage.SetPixel(i + k, j, this.SetColor(stuctElemnt[xcentr + k, ycentr]));
                                    //imageWithZeroaNull[i + k, j] = 1;
                                    if (j + l < sourceImage.Height - 1 && j + l > 0)
                                    {
                                        resultImage.SetPixel(i, j + l, this.SetColor(stuctElemnt[xcentr, ycentr + l]));
                                        resultImage.SetPixel(i + k, j + l, this.SetColor(stuctElemnt[xcentr + k, ycentr + l]));
                                        //imageWithZeroaNull[i , j + l] = 1;

                                    }
                                }
                                /*   if (j + l < sourceImage.Height - 1 && j + l > 0)
                                   {
                                       resultImage.SetPixel(i, j + l, Color.Black);
                                       //imageWithZeroaNull[i + k, j] = 1;
                                       if (i + k < sourceImage.Width - 1 && i + k > 0)
                                       {
                                           resultImage.SetPixel(i + k, j + l, Color.Black);
                                       }

                                   }*/


                            }
                        }
                    }
                    else
                    {
                        resultImage.SetPixel(i, j, Color.Black);
                    }
                 }
             }
            
           /* for (int i = 0; i < sourceImage.Width;i++) 
            {
                for (int j = 0; j < sourceImage.Height; j++)
                { 
                    if (imageWithZeroaNull[i,j] == 1)
                    {
                        resultImage.SetPixel(i,j,Color.White);
                    }
                    else
                    {
                        resultImage.SetPixel(i, j, Color.Black);
                    }
                }
            }*/
            return resultImage;
        }
        public Color SetColor(int a)
        {
            if (a == 1) return Color.White;
            else return Color.Black;
        }

    }
}
