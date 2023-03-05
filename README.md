# ScreenCapture
Pure WPF library for screen/window capture

# Use

* capture full screen to `ImageSource`
``` csharp
var capture = ScreenCaptureProvider.Provide();
var image = capture.CaptureScreen().GetImageSource();
```

* capture a window to raw image
``` csharp
var capture = ScreenCaptureProvider.Provide();
byte[] data = capture.CaptureWindow(hWnd).GetRawBytes();
```

# License
MIT Licence

# Author
dme-compunet
