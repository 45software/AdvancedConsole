using System;


namespace ConsoleApp
{
	public interface IDisposableService : IDisposable
	{
		void DoSomething();
	}
}