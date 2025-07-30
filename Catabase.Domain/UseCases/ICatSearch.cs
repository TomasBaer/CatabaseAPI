using Catabase.Domain.Entities;
using Catabase.Domain.Responses;

namespace Catabase.Domain.UseCases;

public interface ICatSearch
{
	Task<ISearchResponse<Cat>> SearchCatsAsync(string query, int page, int pageSize, CancellationToken ct = default);
	Task<Cat?> GetCatAsync(int id, CancellationToken ct = default);
}
