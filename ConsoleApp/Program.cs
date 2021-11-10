using ClassLib;
using ConsoleApp.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;


namespace ConsoleApp
{
	class Program
	{
		static async Task Main(string[] args)
		{
			using IHost host = Host.CreateDefaultBuilder()
				.ConfigureServices((context, services) =>
				{
					services.AddLogging();
					services.AddOptions();

					services.AddConsoleApp();
					services.AddCustomLibrary();
				})
				.Build();

			await host.Services.GetService<IConsoleService>().RunAsync(args);
		}
	}
}
