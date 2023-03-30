using ClassLib;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;


namespace ConsoleApp.Services;


public sealed class ConsoleService : IConsoleService
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
	}


	public async Task RunAsync(string[] args)
	{
		_logger.LogInformation("The application is now starting...");
		_logger.LogInformation("The Url in the settings file is '{Url}' and use HTTPS is '{UseHttps}'.",
			_options.Url, _options.UseHttps);

		await _service.DoSomethingAsync();
		await _library.DoSomethingSpecialAsync();
	}
}
