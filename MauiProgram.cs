using SvendeTest60.Services;
using SvendeTest60.ViewModels;
using SvendeTest60.Views;

namespace SvendeTest60;

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



        builder.Services.AddTransient<UserApiService>();
        builder.Services.AddTransient<MessageApiService>();


        // Views
        builder.Services.AddSingleton<LoadingPage>();
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<MessagePage>();
        builder.Services.AddSingleton<MessageSendPage>();
        builder.Services.AddSingleton<RegisterPage>();
        builder.Services.AddSingleton<CoursesPage>();
        builder.Services.AddSingleton<SingleCoursePage>();
        builder.Services.AddSingleton<UserProfilePage>();
        builder.Services.AddSingleton<PaySoulutionPage>();

        // ViewModels
        builder.Services.AddSingleton<LoadingViewModel>();
        builder.Services.AddSingleton<LoginViewModel>();
        builder.Services.AddSingleton<HomeViewModel>();
        builder.Services.AddSingleton<MessageViewModel>();
        builder.Services.AddSingleton<RegisterViewModel>();


        return builder.Build();
	}
}
