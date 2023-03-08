using System;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Compunet.ScreenCapture;

internal class CaptureResult : ICaptureResult
{
    private readonly BitmapSource mBitmapSource;

    public CaptureResult(BitmapSource bitmap)
    {
        mBitmapSource = bitmap;
    }

    public BitmapSource GetBitmapSource() => mBitmapSource;

    public ImageSource GetImageSource() => mBitmapSource;

    #region GetBytes

    public byte[] GetBytes() => GetBytes(ImageFormat.Jpeg);

    public byte[] GetBytes(ImageFormat format)
    {
        var encoder = CreateEncoder(format);
        return GetBytes(encoder);
    }

    public byte[] GetBytes(BitmapEncoder encoder)
    {
        using var stream = new MemoryStream();
        WriteTo(stream, encoder);
        return stream.ToArray();
    }

    #endregion

    #region WriteTo

    public void WriteTo(Stream stream) => WriteTo(stream, ImageFormat.Jpeg);

    public void WriteTo(Stream stream, ImageFormat format)
    {
        var encoder = CreateEncoder(format);
        WriteTo(stream, encoder);
    }

    public void WriteTo(Stream stream, BitmapEncoder encoder)
    {
        var frame = BitmapFrame.Create(mBitmapSource);
        encoder.Frames.Add(frame);
        encoder.Save(stream);
    }

    #endregion

    #region WriteToFile

    public void WriteToFile(string path) => WriteToFile(path, ImageFormat.Jpeg);

    public void WriteToFile(string path, ImageFormat format)
    {
        var encoder = CreateEncoder(format);
        WriteToFile(path, encoder);
    }

    public void WriteToFile(string path, BitmapEncoder encoder)
    {
        using var stream = File.OpenWrite(path);
        WriteTo(stream, encoder);
    }

    #endregion

    private static BitmapEncoder CreateEncoder(ImageFormat format)
    {
        return format switch
        {
            ImageFormat.Jpeg => new JpegBitmapEncoder(),
            ImageFormat.Png => new PngBitmapEncoder(),
            ImageFormat.Bmp => new BmpBitmapEncoder(),
            ImageFormat.Gif => new GifBitmapEncoder(),
            ImageFormat.Tiff => new TiffBitmapEncoder(),
            ImageFormat.Wmp => new WmpBitmapEncoder(),
            _ => throw new InvalidOperationException("unknow image format")
        };
    }
}