namespace ConsoleApp.Services;


public interface IConsoleService : IDisposable
{
	Task RunAsync(string[] args);
}