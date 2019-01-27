using InkSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Ink;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Input;
using InkSharp.Extensions;
using System.Windows.Media;
using Color = System.Drawing.Color;
using Pen = System.Drawing.Pen;
using System.IO;
using System.Drawing.Imaging;

namespace InkSharp
{
    public class Drawing : StrokeCollection, IDrawing
    {
        // Static
        public static Bitmap Empty => GetEmptyBitmap();

        // Constructors
        public Drawing()
        {            
            DPI = 96f;
            SmoothingMode = SmoothingMode.AntiAlias;
            PenColor = Color.Black;
            PenStroke = 2.0f;
            Background = Color.White;
        }

        // Properties
        public virtual float DPI { get; set; }
        public virtual float PenStroke { get; set; }
        public virtual Color PenColor { get; set; }
        public virtual Color Background { get; set; }
        public virtual SmoothingMode SmoothingMode { get; set; }

        // Private (static)
        private static Bitmap GetEmptyBitmap()
        {
            var tmp = new Bitmap(1, 1);
            tmp.SetPixel(0, 0, Color.White);
            return tmp;
        }

        // Methods
        public virtual Bitmap ToBitmap()
        {
            var allPoints = GetAllPoints();

            if (allPoints.Count() <= 1)
                return Empty;

            var horizontalOffset = (int)allPoints.Min(point => point.X);
            var verticalOffset = (int)allPoints.Min(point => point.Y);

            var width = (int)allPoints.Max(point => point.X) - horizontalOffset + 1;
            var height = (int)allPoints.Max(point => point.Y) - verticalOffset + 1;

            var bitmap = new Bitmap(width, height);
            bitmap.SetResolution(DPI, DPI);

            var g = Graphics.FromImage(bitmap);
            g.SmoothingMode = SmoothingMode;
            g.Clear(Background);

            var blackPen = new Pen(PenColor, PenStroke);

            foreach (var line in Items)
            {
                var points = line.StylusPoints.Select(x => x.ToPoint());
                var drawingPoints = points.Select(point => new Point(Floor(point.X) - horizontalOffset, Floor(point.Y) - verticalOffset)).ToList();

                if (drawingPoints.Count > 1)
                    g.DrawLines(blackPen, drawingPoints.ToArray());
            }

            return bitmap;
        }
        public virtual ImageSource ToImageSource() => ToBitmap().ToImageSource();
        public virtual string ToBase64()
        {
            using (var ms = new MemoryStream())
            {
                using (var bitmap = ToBitmap())
                {
                    bitmap.Save(ms, ImageFormat.Bmp);
                    return Convert.ToBase64String(ms.GetBuffer());
                }
            }
        }
        public virtual byte[] ToByteArray()
        {
            using (var ms = new MemoryStream())
            {
                using (var bitmap = ToBitmap())
                {
                    bitmap.Save(ms, ImageFormat.Bmp);
                    return ms.GetBuffer();
                }
            }
        }
        public override string ToString()
        {
            return ToByteArray().ToPrettyString();
        }

        // Protected
        protected IEnumerable<StylusPoint> GetAllPoints()
        {
            return Items.SelectMany(x => x.StylusPoints);
        }
        protected int Floor(double number)
        {
            return (int)Math.Floor(number);
        }
    }
}
