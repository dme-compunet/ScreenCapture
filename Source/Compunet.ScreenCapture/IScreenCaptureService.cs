namespace Compunet.ScreenCapture;

public interface IScreenCaptureService
{
    ICaptureResult CaptureScreen();
    ICaptureResult CaptureWindow(nint hWnd);
}
