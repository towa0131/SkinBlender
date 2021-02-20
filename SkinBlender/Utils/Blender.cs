using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace SkinBlender.Utils
{
    class Blender
    {
        public static Bitmap Blend(Bitmap head, Bitmap body)
        {
            Bitmap map = body.Clone() as Bitmap;
            for (int y = 0; y < 16; ++y)
            {
                for (int x = 0; x < 64; ++x)
                {
                    map.SetPixel(x, y, head.GetPixel(x, y));
                }
            }

            return map;
        }
    }
}
