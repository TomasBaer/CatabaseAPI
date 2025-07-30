using Catabase.Domain.UseCases;

namespace Catabase.Api.Api.Cats.Search;

public class SearchCatsService(ICatSearch catSearchService) : ISearchCatsService
{
	private readonly ICatSearch _catSearchService = catSearchService;

	public async Task<SearchCatsResponse> SearchCatsAsync(string? query, int page, int pageSize, CancellationToken ct = default)
	{
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
