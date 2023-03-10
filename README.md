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
var screenshot = screenCapture.CaptureWindow(hWnd);
byte[] raw = screenshot.GetBytes();
```

-   capture full screen to file in bmp format

```csharp
var screenCapture = new ScreenCaptureService();
var screenshot = screenCapture.CaptureScreen();
screenshot.WriteToFile(path, ImageFormat.Bmp);
```

# NuGet
https://www.nuget.org/packages/Compunet.ScreenCapture

# License

MIT License

# Author

dme-compunet
