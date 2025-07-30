using Catabase.Domain.UseCases;

namespace Catabase.Api.Api.Cats.Search;

public class SearchCatsService(ICatSearch catSearchService) : ISearchCatsService
{
	private readonly ICatSearch _catSearchService = catSearchService;

	public async Task<SearchCatsResponse> SearchCatsAsync(string? query, int page, int pageSize, CancellationToken ct = default)
	{
		if (page < 0)
		{
			throw new ArgumentOutOfRangeException(nameof(page), "Page number cannot be negative.");
		}

		if (pageSize <= 0)
		{
			throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size must be a positive integer.");
		}

		if (string.IsNullOrWhiteSpace(query))
		{
			query = string.Empty;
		}

		var searchResponse = await _catSearchService.SearchCatsAsync(query, page, pageSize, ct);

		var response = new SearchCatsResponse()
		{
			TotalCount = searchResponse.TotalCount,
			Items = searchResponse.Items.Select(cat => new CatResponse
			{
				Id = cat.Id,
				Name = cat.Name,
				Age = cat.Age,
				PrimaryColor = cat.PrimaryColor
			})
		};

		return response;
	}
}
