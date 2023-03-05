using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Compunet.ScreenCapture;

public interface ICapturedImage
{
    ImageSource GetImageSource();
    BitmapSource GetBitmapSource();

    byte[] GetBytes();
    byte[] GetBytes(BitmapEncoder encoder);

    void WriteTo(Stream stream);
    void WriteTo(Stream stream, BitmapEncoder encoder);

    void WriteToFile(string path);
    void WriteToFile(string path, BitmapEncoder encoder);
}
