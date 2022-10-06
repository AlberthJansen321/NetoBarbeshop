using NetoBarbeshop.APP.Service;
using NetoBarbeshop.APP.Service.Interface;
using NetoBarbeshop.APP.ViewModels;
using NetoBarbeshop.APP.Views;

namespace NetoBarbeshop.APP;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            fonts.AddFont("OpenSans-Bold.ttf", "OpenSansBold");
            fonts.AddFont("Sitka.ttc", "Sitka");
        });

        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
        //services 
        builder.Services.AddSingleton<IHomeService, HomeService>();
        builder.Services.AddSingleton<ILoginService, LoginService>();
        //views
        builder.Services.AddSingleton<Login>();
        builder.Services.AddSingleton<Home>();
        builder.Services.AddSingleton<Loading>();
        builder.Services.AddSingleton<Add>();
        //models
        builder.Services.AddSingleton<LoginPageViewModel>();
        builder.Services.AddSingleton<HomePageViewModel>();
        builder.Services.AddSingleton<LoadingPageViewModel>();

        return builder.Build();
    }
}