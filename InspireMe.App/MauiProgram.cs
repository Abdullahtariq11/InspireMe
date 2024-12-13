using InspireMe.App.Pages;
using InspireMe.App.Service;
using InspireMe.App.ViewModels;
using Microsoft.Extensions.Logging;

namespace InspireMe.App;

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
			builder.Services.AddSingleton<HomePageViewModel>();
			builder.Services.AddSingleton<IQuoteService, QuoteService>();
			builder.Services.AddSingleton<HomePage>();
			builder.Services.AddSingleton<FavouritePage>();
			builder.Services.AddSingleton<AppShell>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
