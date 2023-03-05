using System.Runtime.InteropServices;

namespace Compunet.ScreenCapture.Interop;

internal static partial class Gdi32
{
    private const string LibraryName = "gdi32.dll";

    public const int SRCCOPY = 0x00CC0020; // BitBlt dwRop parameter

    [LibraryImport(LibraryName)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool BitBlt(nint hObject,
                                      int nXDest,
                                      int nYDest,
                                      int nWidth,
                                      int nHeight,
                                      nint hObjectSource,
                                      int nXSrc,
                                      int nYSrc,
                                      int dwRop);

    [LibraryImport(LibraryName)]
    public static partial nint CreateCompatibleBitmap(nint hDC, int nWidth, int nHeight);

    [LibraryImport(LibraryName)]
    public static partial nint CreateCompatibleDC(nint hDC);

    [LibraryImport(LibraryName)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool DeleteDC(nint hDC);

    [LibraryImport(LibraryName)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool DeleteObject(nint hObject);

    [LibraryImport(LibraryName)]
    public static partial nint SelectObject(nint hDC, nint hObject);
}