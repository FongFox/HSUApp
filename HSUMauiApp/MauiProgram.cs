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
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Đăng ký ApiService và LoginViewModel
        builder.Services.AddSingleton<ApiService>();
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<LandingPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}