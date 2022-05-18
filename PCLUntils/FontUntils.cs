using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PCLUntils
{
    public static class FontUntils
    {
        public static SizeF MeasureString(this string text, Font font, double maxwidth)
        {
            try
            {
                var p = Graphics.FromImage(new Bitmap(1, 1)).MeasureString(text, font, Convert.ToInt32(maxwidth * 96f / 100f));
                return new SizeF(p.Width * 100f / 96f, p.Height * 100f / 96f);
            }
            catch
            {
                return new SizeF();
            }
        }
    }
}