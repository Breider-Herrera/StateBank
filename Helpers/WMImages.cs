using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoEstatal.Helpers
{
    public class WMImages
    {
        public static byte[] Image2Byte(Image img)
        {
            using (var ms = new MemoryStream())
            {
                img.Save(ms, img.RawFormat);
                return ms.ToArray();
            }
        }

        public static Image Byte2Image(byte[] b)
        {
            using (var ms = new MemoryStream(b))
                return Image.FromStream(ms);
        }
    }
}
