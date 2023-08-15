using System;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using Compunet.ScreenCapture.Interop;

using static Compunet.ScreenCapture.Interop.Gdi32;
using static Compunet.ScreenCapture.Interop.User32;

namespace Compunet.ScreenCapture;

public class ScreenCaptureService : IScreenCaptureService
{
    public IScreenshot CaptureScreen()
    {
        var screen = CaptureWindowCore(GetDesktopWindow());
        return new Screenshot(screen);
    }

    public IScreenshot CaptureWindow(nint hWnd)
    {
        var window = CaptureWindowCore(hWnd);
        return new Screenshot(window);
    }

    private static BitmapSource CaptureWindowCore(nint hWnd)
    {
        // get te hDC of the target window
        IntPtr hdcSrc = GetWindowDC(hWnd);

        // get the window rect
        var rect = GetWindowRect(hWnd);

        // create a device context we can copy to
        IntPtr hdcDest = CreateCompatibleDC(hdcSrc);

        // create a bitmap we can copy it to,
        // using GetWindowRect to get the width/height
        IntPtr hBitmap = CreateCompatibleBitmap(hdcSrc, rect.Width, rect.Height);

        // select the bitmap object
        IntPtr hOld = SelectObject(hdcDest, hBitmap);

        // bitblt over
        BitBlt(hdcDest, 0, 0, rect.Width, rect.Height, hdcSrc, 0, 0, SRCCOPY);

        // restore selection
        SelectObject(hdcDest, hOld);

        // clean up
        DeleteDC(hdcDest);
        ReleaseDC(hWnd, hdcSrc);

        // get a .NET BitmapSource object for it
        BitmapSource bitmap
            = Imaging.CreateBitmapSourceFromHBitmap(
                hBitmap,
                default,
                rect,
                BitmapSizeOptions.FromEmptyOptions());


        // free up the Bitmap object
        DeleteObject(hBitmap);

        // return the BitmapSource object
        return bitmap;
    }

    private static Int32Rect GetWindowRect(nint hWnd)
    {
        RECT windowRect = new();
        User32.GetWindowRect(hWnd, ref windowRect);

        return new(
            Math.Max(0, windowRect.left),
            Math.Max(0, windowRect.top),
            Math.Max(0, windowRect.right - windowRect.left),
            Math.Max(0, windowRect.bottom - windowRect.top));
    }
}
