using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media;
using Color = System.Drawing.Color;

namespace InkSharp.Interfaces
{
    public interface IDrawing
    {
        // Properties
        float DPI { get; set; }
        float PenStroke { get; set; }
        Color Background { get; set; }
        Color PenColor { get; set; }
        bool IsEmpty { get; }

        // Methods
        Bitmap ToBitmap();
        ImageSource ToImageSource();
        string ToBase64();
        byte[] ToByteArray();
        void Clear();
    }
}
