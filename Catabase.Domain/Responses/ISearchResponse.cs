namespace Catabase.Domain.Responses;

public interface ISearchResponse<T>
	where T : class
{
	public int TotalCount { get; }
	public IEnumerable<T> Items { get; }
}
