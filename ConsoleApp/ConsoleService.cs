using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;


namespace ConsoleApp
{
	public class ConsoleService : IConsoleService
	{
		private readonly IDisposableService _service;
		private readonly ILogger<ConsoleService> _logger;
		private readonly CustomOptions _options;


		public ConsoleService(IDisposableService service,
									ILogger<ConsoleService> logger,
									IOptions<CustomOptions> options)
		{
			_service = service;
			_logger = logger;
			_options = options.Value;
		}


		public void Dispose()
		{
			Console.WriteLine($"Disposing {nameof(ConsoleService)}");
			GC.SuppressFinalize(this);
		}


		public async Task RunAsync(string[] args)
		{
			_logger.LogInformation("The application is now starting {Start}", DateTime.Now);
			Console.WriteLine($"The Url in the settings file is '{_options.Url}'");
			_service.DoSomething();

			await Task.Yield();
		}
	}
}
