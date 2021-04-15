using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;


namespace ConsoleApp
{
	class Program
	{
		static async Task Main(string[] args)
		{
			IHost host = Host.CreateDefaultBuilder()
								.ConfigureServices((context, services) =>
								{
									services.Configure<CustomOptions>(context.Configuration
																							.GetSection(CustomOptions.Section));

									services.AddTransient<IDisposableService, DisposableService>();
									services.AddTransient<IConsoleService, ConsoleService>();

									services.AddLogging();
									services.AddOptions();
								})
								.Build();

			await host.Services.GetService<IConsoleService>().RunAsync(args);

			host.Dispose();
		}
	}
}
