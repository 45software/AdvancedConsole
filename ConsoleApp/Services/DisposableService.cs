using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;


namespace ConsoleApp.Services;


public sealed class DisposableService : IDisposableService
{
	private readonly TaskOptions _configuration;
	private readonly ILogger<DisposableService> _logger;


	public DisposableService(IOptions<TaskOptions> options, ILogger<DisposableService> logger)
	{
		_configuration = options.Value;
		_logger = logger;
	}


	public void Dispose()
	{
		_logger.LogInformation("DisposableService.Dispose() has been called.");
		GC.SuppressFinalize(this);
		// Call dispose on object instances requiring it.
	}


	public async Task DoSomethingAsync(CancellationToken cancellationToken)
	{
		_logger.LogInformation("The DisposableService is doing something...");
		_logger.LogInformation("Task from command line is {Task} with a delay of {Delay}", _configuration.Task, _configuration.Delay);
		try
		{
			await Task.Delay(_configuration.Delay > 0 ? _configuration.Delay : 1500, cancellationToken);
		}
		catch (TaskCanceledException)
		{
			_logger.LogInformation("DisposableService detected a shutdown");
		}
	}
}
