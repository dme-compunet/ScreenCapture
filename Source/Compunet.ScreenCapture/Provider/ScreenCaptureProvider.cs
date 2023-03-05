namespace Compunet.ScreenCapture.Provider;

public static class ScreenCaptureProvider
{
    public static IScreenCapture Provide() => new ScreenCaptureService();
}
