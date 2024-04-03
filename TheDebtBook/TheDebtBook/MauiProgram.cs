using Microsoft.Extensions.DependencyInjection;
using TheDebtBook.Data;
using TheDebtBook.ViewModels;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using TheDebtBook.Views;

namespace TheDebtBook
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.UseMauiCommunityToolkit()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				});

			// Register the database service
			builder.Services.AddSingleton<IDatabase, Database>();

			// Register ViewModel services
			builder.Services.AddSingleton<MainPage>();
			builder.Services.AddSingleton<MainViewModel>();

            builder.Services.AddTransient<AddDebtorPage>();
            builder.Services.AddTransient(sp => new AddDebtorViewModel(sp.GetRequiredService<IDatabase>()));

            builder.Services.AddTransient<ShowDebtorsPage>();
            builder.Services.AddTransient(sp => new ShowDebtorsViewModel(sp.GetRequiredService<IDatabase>()));

#if DEBUG
            builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}