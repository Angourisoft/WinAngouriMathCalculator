using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMath;

namespace Calculator
{
    public static class Latexer
    {
        private static TexFormulaParser parser = new WpfMath.TexFormulaParser();

        public static Image RenderLatex(string latex, int maxWidth)
        {
            var formula = parser.Parse(latex);
            var renderer = formula.GetRenderer(WpfMath.TexStyle.Display, 60.0, "Arial");
            var bitmapSource = renderer.RenderToBitmap(0, 0);
            var encoder = new System.Windows.Media.Imaging.PngBitmapEncoder();
            encoder.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(bitmapSource));

            MemoryStream stream = new MemoryStream();
            encoder.Save(stream);
            var rawRes = Image.FromStream(stream);

            return maxWidth < rawRes.Width ? resizeImage(rawRes, new Size(maxWidth, maxWidth * rawRes.Height / rawRes.Width)) : rawRes;
        }

        private static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
    }
}
