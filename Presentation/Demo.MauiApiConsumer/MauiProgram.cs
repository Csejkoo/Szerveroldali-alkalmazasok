using Microsoft.Extensions.Logging;
using Demo.ApiClient1.IoC;

namespace Demo.MauiApiConsumer
{
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
            builder.Services.AddDemoApiClientService(x => x.ApiBaseAddress = "http://10.0.2.2:5234/");
            builder.Services.AddTransient<MainPage> ();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
