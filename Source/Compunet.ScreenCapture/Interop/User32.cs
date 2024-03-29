﻿using System.Runtime.InteropServices;

namespace Compunet.ScreenCapture.Interop;

internal static partial class User32
{
    private const string LibraryName = "user32.dll";

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }

    [LibraryImport(LibraryName)]
    public static partial nint GetDesktopWindow();

    [LibraryImport(LibraryName)]
    public static partial nint GetForegroundWindow();

    [LibraryImport(LibraryName)]
    public static partial nint GetWindowDC(nint hWnd);

    [LibraryImport(LibraryName)]
    public static partial nint ReleaseDC(nint hWnd, nint hDC);

    [LibraryImport(LibraryName)]
    public static partial nint GetWindowRect(nint hWnd, ref RECT rect);
}