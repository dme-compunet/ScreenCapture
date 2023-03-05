namespace Compunet.ScreenCapture;

public interface IScreenCapture
{
    ICapturedImage CaptureScreen();
    ICapturedImage CaptureWindow(nint hWnd);
}
