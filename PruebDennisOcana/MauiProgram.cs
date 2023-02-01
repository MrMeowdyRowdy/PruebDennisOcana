using PruebDennisOcana.Services;
using PruebDennisOcana.ViewModels;
using PruebDennisOcana.Views;

namespace PruebDennisOcana;

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

        builder.Services.AddSingleton<InterfazBDD, BDD>();

        builder.Services.AddSingleton<ImageList>();
        builder.Services.AddSingleton<AddUpdateImage>();

        builder.Services.AddSingleton<AddupdateImageModel>();

        builder.Services.AddSingleton<MainPage>();


        builder.Services.AddSingleton<ImageListModel>();

        return builder.Build();
	}
}
