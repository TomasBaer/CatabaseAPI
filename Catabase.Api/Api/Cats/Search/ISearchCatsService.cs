using Catabase.Application.Responses;

namespace Catabase.Api.Api.Cats.Search;

public interface ISearchCatsService
{
	Task<SearchCatsResponse> SearchCatsAsync(string? query, int page, int pageSize, CancellationToken cancellationToken = default);
}
