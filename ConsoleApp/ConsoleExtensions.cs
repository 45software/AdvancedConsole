using ConsoleApp.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ConsoleApp;


public static class ConsoleExtensions
{
	public static IServiceCollection AddConsoleApp(this IServiceCollection services)
	{
		services.AddOptions<CustomOptions>()
			.Configure<IConfiguration>((settings, configuration) =>
			{
				configuration.GetSection(CustomOptions.Section).Bind(settings);
			});

		services.AddTransient<IDisposableService, DisposableService>();
		services.AddTransient<IConsoleService, ConsoleService>();

		return services;
	}
}
