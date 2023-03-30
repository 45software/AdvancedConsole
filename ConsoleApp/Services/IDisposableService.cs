namespace ConsoleApp.Services;


public interface IDisposableService : IDisposable
{
	Task DoSomethingAsync();
}