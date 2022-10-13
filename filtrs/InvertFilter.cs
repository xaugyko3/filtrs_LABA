﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filtrs
{
    class InvertFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);   
            Color resultColor = Color.FromArgb(255 - sourceColor.R,
                                               255 - sourceColor.G, 
                                               255 - sourceColor.B);    
            return resultColor;
        }
    }
        
    
}
