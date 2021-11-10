﻿using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;


namespace ConsoleApp.Services
{
	public class DisposableService : IDisposableService
	{
		private readonly ILogger<DisposableService> _logger;


		public DisposableService(ILogger<DisposableService> logger)
		{
			_logger = logger;
		}


		public void Dispose()
		{
			_logger.LogInformation("DisposableService.Dispose() has been called.");
			GC.SuppressFinalize(this);
		}


		public async Task DoSomethingAsync()
		{
			_logger.LogInformation("The DisposableService is doing something...");
			await Task.Delay(1500);
		}
	}
}
