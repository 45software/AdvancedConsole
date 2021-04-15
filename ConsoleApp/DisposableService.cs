using System;


namespace ConsoleApp
{
	public class DisposableService : IDisposableService
	{
		public void Dispose()
		{
			Console.WriteLine("Disposing a disposable service");
			GC.SuppressFinalize(this);
		}


		public void DoSomething()
		{
			Console.WriteLine("I'm doing some work");
		}
	}
}
