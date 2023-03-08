# ScreenCapture

Pure WPF library for screen/window capture (screenshot)

# Use

-   capture full screen to `ImageSource` object

```csharp
var screenCapture = new ScreenCaptureService();
var imageSource = screenCapture.CaptureScreen().GetImageSource();
```

-   capture a window to image bytes data

```csharp
var screenCapture = new ScreenCaptureService();
byte[] raw = screenCapture.CaptureWindow(hWnd).GetBytes();
```

-   capture full screen to file in bmp format

```csharp
var screenCapture = new ScreenCaptureService();
screenCapture.CaptureScreen().WriteToFile(path, ImageFormat.Bmp);
```

# License

MIT License

# Author

dme-compunet
