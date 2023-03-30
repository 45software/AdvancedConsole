using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;


namespace ClassLib;


public sealed class LibraryService : ILibraryService
{
	private readonly ILogger<LibraryService> _logger;
	private readonly LibraryOptions _options;


	public LibraryService(IOptions<LibraryOptions> options, ILogger<LibraryService> logger)
	{
		_options = options.Value;
		_logger = logger;
	}


	public async Task DoSomethingSpecialAsync()
	{
		_logger.LogInformation("The library service is doing something special.");
		await Task.Delay(1500);
		_logger.LogInformation("{Sender} has a special message for you '{Message}'",
			_options.Sender, _options.Message);
	}
}
