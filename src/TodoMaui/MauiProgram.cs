using CommunityToolkit.Maui;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System.Data;
using TodoMaui.Pages;
using TodoMaui.Repositories;
using TodoMaui.ViewModels;

namespace TodoMaui;

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

#if DEBUG
		builder.Logging.AddDebug();
#endif
        builder.Services.AddTransient<TodoPage>();
        builder.Services.AddTransient<TodoViewModel>();
        builder.Services.AddTransient<TodoRepository>();

        builder.Services.AddTransient<IDbConnection>(_ => {
#if ANDROID
			return new SqlConnection("Server=10.0.2.2,1433;Database=TODOAPPDB;User Id=sa;Password=password123!;Encrypt=false;Application Name=MauiTodo;");
#else
            return new SqlConnection("Server=localhost,1433;Database=TODOAPPDB;User Id=sa;Password=password123!;Encrypt=false");
#endif
        });
        return builder.Build();
	}
}
