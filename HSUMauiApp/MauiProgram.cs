using Microsoft.Extensions.Logging;
using HSUMauiApp.Services;
using HSUMauiApp.ViewModels;
using HSUMauiApp.Views;

namespace HSUMauiApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("fa-solid-900.ttf", "FASolid");
                fonts.AddFont("fa-regular-400.ttf", "FARegular");
            });

        // Đăng ký ApiService và LoginViewModel
        builder.Services.AddSingleton<ApiService>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<HomeViewModel>();
        builder.Services.AddTransient<LandingPage>();
        builder.Services.AddTransient<HomePage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}