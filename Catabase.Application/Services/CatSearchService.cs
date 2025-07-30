using Catabase.Application.Interfaces;
using Catabase.Application.Responses;
using Catabase.Domain.Entities;
using Catabase.Domain.Responses;
using Catabase.Domain.UseCases;

namespace Catabase.Application.Services;

public class CatSearchService(ICatRepository catRepository) : ICatSearch
{
	private readonly ICatRepository _catRepository = catRepository;

	public async Task<ISearchResponse<Cat>> SearchCatsAsync(string query, int page, int pageSize, CancellationToken ct = default)
	{
		var searchResults = await _catRepository.SearchCatsAsync(query, page, pageSize, ct);

		return new CatSearchResponse()
		{
			TotalCount = searchResults.Item2,
			Items = searchResults.Item1
		};
	}

	public Task<Cat?> GetCatAsync(int id, CancellationToken ct = default)
	{
		throw new NotImplementedException();
	}
}
