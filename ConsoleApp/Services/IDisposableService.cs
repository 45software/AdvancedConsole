using System;
using System.Threading.Tasks;


namespace ConsoleApp.Services
{
	public interface IDisposableService : IDisposable
	{
		Task DoSomethingAsync();
	}
}