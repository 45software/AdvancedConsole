using ConsoleApp.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace ConsoleApp;


public static class ConsoleExtensions
{
	public static IServiceCollection AddConsoleApp(this IServiceCollection services)
	{
		services.AddOptions<CustomOptions>()
			.Configure<IConfiguration>((options, configuration) =>
			{
				configuration.GetSection(CustomOptions.Section).Bind(options);
			});

		services.AddOptions<TaskOptions>()
			.Configure<IConfiguration>((options, configuration) =>
			{
				configuration.Bind(options);
			});

		services.AddTransient<IDisposableService, DisposableService>();
		services.AddTransient<IHostedService, ConsoleService>();

		return services;
	}
}
