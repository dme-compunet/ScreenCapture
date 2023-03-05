using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Compunet.ScreenCapture;

internal class WindowCaptureInfo : ICapturedImage
{
    private readonly BitmapSource mBitmapSource;

    public WindowCaptureInfo(BitmapSource bitmap)
    {
        mBitmapSource = bitmap;
    }

    public BitmapSource GetBitmapSource() => mBitmapSource;

    public ImageSource GetImageSource() => mBitmapSource;

    #region WriteTo

    public void WriteTo(Stream stream) => WriteTo(stream, new JpegBitmapEncoder());

    public void WriteTo(Stream stream, BitmapEncoder encoder)
    {
        var frame = BitmapFrame.Create(mBitmapSource);
        encoder.Frames.Add(frame);
        encoder.Save(stream);
    }

    #endregion

    #region GetBytes

    public byte[] GetBytes() => GetBytes(new JpegBitmapEncoder());

    public byte[] GetBytes(BitmapEncoder encoder)
    {
        using var stream = new MemoryStream();
        WriteTo(stream, encoder);
        return stream.ToArray();
    }

    #endregion

    #region WriteToFile

    public void WriteToFile(string path)
    {
        WriteToFile(path, new JpegBitmapEncoder());
    }

    public void WriteToFile(string path, BitmapEncoder encoder)
    {
        using var stream = File.OpenWrite(path);
        WriteTo(stream, encoder);
    }

    #endregion
}
