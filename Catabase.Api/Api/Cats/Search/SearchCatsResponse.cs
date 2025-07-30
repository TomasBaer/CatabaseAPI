using Catabase.Domain.Enums;
using Catabase.Domain.Responses;

namespace Catabase.Api.Api.Cats.Search;

public class SearchCatsResponse : ISearchResponse<CatResponse>
{
	public int TotalCount { get; set; }
	public IEnumerable<CatResponse> Items { get; set; } = [];
}

public class CatResponse
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public int? Age { get; set; }
	public CoatColor PrimaryColor { get; set; }
}
