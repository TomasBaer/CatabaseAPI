using Catabase.Application.Interfaces;
using Catabase.Application.Responses;
using Catabase.Domain.Entities;
using Catabase.Domain.Responses;
using Catabase.Domain.UseCases;
using Microsoft.Extensions.Logging;

namespace Catabase.Application.Services;

public class CatSearchService(ICatRepository catRepository, ILogger<CatSearchService> logger) : ICatSearch
{
	private readonly ICatRepository _catRepository = catRepository;
	private readonly ILogger<CatSearchService> _logger = logger;

	public async Task<ISearchResponse<Cat>> SearchCatsAsync(string query, int page, int pageSize, CancellationToken ct = default)
	{
		_logger.LogInformation("Searching for cats with query: {Query}, page: {Page}, pageSize: {PageSize}", query, page, pageSize);

		var searchResults = await _catRepository.SearchCatsAsync(query, page, pageSize, ct);

		_logger.LogInformation("Found {TotalCount} cats matching the query.", searchResults.Item2);

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
