using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using ZXing.Net.Maui.Controls;
using ZXing.Net.Maui;
namespace Service
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
                })
             .UseBarcodeReader();

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddTransient<AddOfferPageViewModel>(sp =>
                 new AddOfferPageViewModel(sp.GetRequiredService<MainPageViewModel>()));
            builder.Services.AddTransient<AddOfferPage>(); // Регистрируем AddOfferPage
            return builder.Build();

        }
    }
}
