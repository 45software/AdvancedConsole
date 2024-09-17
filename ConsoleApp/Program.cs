using ClassLib;
using ConsoleApp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


// Configuration setup
IHostBuilder builder = Host.CreateDefaultBuilder(args);
builder.ConfigureAppConfiguration(c =>
{
	c.AddCommandLine(args);
});

builder.ConfigureServices(services =>
{
	services.AddLogging();
	services.AddOptions();

	services.AddConsoleApp();
	services.AddCustomLibrary();
});

using IHost host = builder.Build();


// Setup shutdown process
using CancellationTokenSource tokenSource = new();
Console.CancelKeyPress += Shutdown;

IHostedService? service = host.Services.GetService<IHostedService>();
if (service != null)
{
	await service.StartAsync(tokenSource.Token);
	await service.StopAsync(tokenSource.Token);
}
else
{
	Console.WriteLine("Error: Failed to get a reference to the service");
}

Console.CancelKeyPress -= Shutdown;

// Perform custom shutdown actions when the program is forced to quit
void Shutdown(object? sender, ConsoleCancelEventArgs e)
{
	e.Cancel = true;
	tokenSource.Cancel();
}
