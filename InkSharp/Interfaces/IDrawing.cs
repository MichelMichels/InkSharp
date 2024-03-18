using System.Drawing;
using System.Windows.Media;

namespace MichelMichels.InkSharp.Interfaces;

public interface IDrawing
{
    // Properties
    float DPI { get; set; }
    float PenStroke { get; set; }
    System.Drawing.Color Background { get; set; }
    System.Drawing.Color PenColor { get; set; }
    bool IsEmpty { get; }

    // Methods
    Bitmap ToBitmap();
    ImageSource ToImageSource();
    string ToBase64();
    byte[] ToByteArray();
    void Clear();
}
