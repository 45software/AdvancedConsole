using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			using IHost host = ConfigureHost();

			host.Services.GetService<IConsoleService>().Run(args);
		}


		static private IHost ConfigureHost()
		{
			return Host.CreateDefaultBuilder()
						.ConfigureServices((context, services) =>
						{
							services.Configure<CustomOptions>(context.Configuration
																					.GetSection(CustomOptions.Section));

							services.AddTransient<IConsoleService, ConsoleService>();

							services.AddLogging();
							services.AddOptions();
						})
						.Build();
		}
	}
}
