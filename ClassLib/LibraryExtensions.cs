using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ClassLib;


public static class LibraryExtensions
{
	public static IServiceCollection AddCustomLibrary(this IServiceCollection services)
	{
		services.AddOptions<LibraryOptions>()
			.Configure<IConfiguration>((options, configuration) =>
			{
				configuration.GetSection(LibraryOptions.Section).Bind(options);
			});

		services.AddTransient<ILibraryService, LibraryService>();

		return services;
	}
}
