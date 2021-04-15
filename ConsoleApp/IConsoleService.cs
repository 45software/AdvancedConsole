using System;
using System.Threading.Tasks;


namespace ConsoleApp
{
	public interface IConsoleService : IDisposable
	{
		Task RunAsync(string[] args);
	}
}