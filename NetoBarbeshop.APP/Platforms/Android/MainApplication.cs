using Android.App;
using Android.Runtime;

namespace NetoBarbeshop.APP;

[Application(UsesCleartextTraffic =true)]
public class MainApplication : MauiApplication
{
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
	}

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
