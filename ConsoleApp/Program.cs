using ClassLib;
using ConsoleApp;
using ConsoleApp.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


using IHost host = Host.CreateDefaultBuilder()
	.ConfigureServices(services =>
	{
		services.AddLogging();
		services.AddOptions();

		services.AddConsoleApp();
		services.AddCustomLibrary();
	})
	.Build();

await host.Services.GetService<IConsoleService>()!.RunAsync(args);
