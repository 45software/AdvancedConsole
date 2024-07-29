namespace ClassLib;


public interface ILibraryService
{
	Task DoSomethingSpecialAsync(CancellationToken cancellationToken);
}
