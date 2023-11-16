using HikeApp.Services;
using HikeApp.ViewModels;
using HikeApp.Views;
using Microsoft.Extensions.Logging;

namespace HikeApp
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

            // Services
            builder.Services.AddSingleton<IHikeService,HikeService>();

            // Views Registration
            builder.Services.AddSingleton<HikeListPage>();
            builder.Services.AddTransient<AddUpdateHikeDetail>();

            //View Modules
            builder.Services.AddSingleton<HikeListPageViewModel>();
            builder.Services.AddTransient<AddUpdateHikeDetailViewModel>();


            return builder.Build();
        }
    }
}