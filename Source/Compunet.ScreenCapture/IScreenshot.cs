using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Compunet.ScreenCapture;

public interface IScreenshot
{
    ImageSource GetImageSource();
    BitmapSource GetBitmapSource();

    byte[] GetBytes();
    byte[] GetBytes(ImageFormat format);
    byte[] GetBytes(BitmapEncoder encoder);

    void WriteTo(Stream stream);
    void WriteTo(Stream stream, ImageFormat format);
    void WriteTo(Stream stream, BitmapEncoder encoder);

    void WriteToFile(string path);
    void WriteToFile(string path, ImageFormat format);
    void WriteToFile(string path, BitmapEncoder encoder);
}