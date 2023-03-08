namespace Compunet.ScreenCapture;

public interface IScreenCaptureService
{
    IScreenshot CaptureScreen();
    IScreenshot CaptureWindow(nint hWnd);
}
