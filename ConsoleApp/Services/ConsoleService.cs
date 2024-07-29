using ClassLib;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;


namespace ConsoleApp.Services;


public sealed class ConsoleService : IHostedService, IDisposable
{
	private readonly IDisposableService _service;
	private readonly ILibraryService _library;
	private readonly ILogger<ConsoleService> _logger;
	private readonly CustomOptions _options;


	public ConsoleService(IDisposableService service,
						ILibraryService library,
						ILogger<ConsoleService> logger,
						IOptions<CustomOptions> options)
	{
		_service = service;
		_library = library;
		_logger = logger;
		_options = options.Value;
	}


	public void Dispose()
	{
		_logger.LogInformation("Console.Dispose() has been called.");
		GC.SuppressFinalize(this);
		// Call Dispose on object instances that require it - notice the disposable service it not disposed
		// because the DI container allocated the object instance.
	}


	public async Task StartAsync(CancellationToken cancellationToken)
	{
		_logger.LogInformation("The application is now starting...");
		_logger.LogInformation("The Url in the settings file is '{Url}' and use HTTPS is '{UseHttps}'.",
			_options.Url, _options.UseHttps);

		await _service.DoSomethingAsync(cancellationToken);
		await _library.DoSomethingSpecialAsync(cancellationToken);
	}


	public Task StopAsync(CancellationToken cancellationToken)
	{
		_logger.LogInformation("The application is shutting down");
		return Task.CompletedTask;
	}
}
