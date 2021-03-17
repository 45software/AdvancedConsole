using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;


namespace ConsoleApp
{
	public class ConsoleService : IConsoleService
	{
		private readonly ILogger<ConsoleService> _logger;
		private readonly IOptions<CustomOptions> _options;


		public ConsoleService(ILogger<ConsoleService> logger,
									IOptions<CustomOptions> options)
		{
			_logger = logger;
			_options = options;
		}


		public void Run(string[] args)
		{
			_logger.LogInformation("The application is now starting {Start}", DateTime.Now);
			Console.WriteLine($"The Url in the settings file is '{_options.Value.Url}'");
		}
	}
}
