using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			IHost host = Host.CreateDefaultBuilder()
								.ConfigureServices((context, services) =>
								{
									services.Configure<CustomOptions>(context.Configuration
																							.GetSection(CustomOptions.Section));

									services.AddTransient<IConsoleService, ConsoleService>();

									services.AddLogging();
									services.AddOptions();
								})
								.Build();

			IConsoleService service = ActivatorUtilities.CreateInstance<ConsoleService>(host.Services);
			service.Run(args);
		}
	}
}
