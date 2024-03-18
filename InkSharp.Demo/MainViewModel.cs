using MichelMichels.InkSharp.Demo.Base;
using MichelMichels.InkSharp.Interfaces;
using Microsoft.Win32;
using System.Drawing.Imaging;
using System.Windows.Input;
using System.Windows.Media;
using Color = System.Drawing.Color;

namespace MichelMichels.InkSharp.Demo;

public class MainViewModel : BaseViewModel
{
    private IDrawing _signature;
    private ImageSource _printedSignature;
    private string _base64EncodedImage, _arrayString;

    public MainViewModel()
    {
        _signature = new Drawing
        {
            PenColor = Color.Blue,
            DPI = 96f
        };
    }

    public ICommand PrintBitmapCommand => new Command(() => PrintedSignature = Signature.ToImageSource());
    public ICommand ClearCommand => new Command(() => Signature.Clear());
    public ICommand SaveCommand => new Command(() => Save());
    public ICommand EncodeCommand => new Command(() => Base64EncodedImage = Signature.ToBase64());
    public ICommand ArrayCommand => new Command(() => ArrayString = Signature.ToString());

    public IDrawing Signature
    {
        get => _signature;
        set => SetProperty(ref _signature, value);
    }
    public ImageSource PrintedSignature
    {
        get => _printedSignature;
        set => SetProperty(ref _printedSignature, value);
    }
    public string Base64EncodedImage
    {
        get => _base64EncodedImage;
        set => SetProperty(ref _base64EncodedImage, value);
    }
    public string ArrayString
    {
        get => _arrayString;
        set => SetProperty(ref _arrayString, value);
    }

    private void Save()
    {
        var saveFileDialog = new SaveFileDialog();

        if (saveFileDialog.ShowDialog() == true)
        {
            Signature.ToBitmap().Save(saveFileDialog.FileName, ImageFormat.Png);
        }
    }
}
