using Catabase.Domain.Entities;
using Catabase.Domain.Responses;

namespace Catabase.Application.Responses;

public record CatSearchResponse : ISearchResponse<Cat>
{
	public int TotalCount { get; set; }
	public IEnumerable<Cat> Items { get; set; } = [];
}
