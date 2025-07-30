using Catabase.Domain.Entities;
using Catabase.Domain.Enums;
using Catabase.Domain.Responses;

namespace Catabase.Application.Responses;

public record SearchCatsResponse : ISearchResponse<Cat>
{
	public int TotalCount { get; set; }
	public IEnumerable<Cat> Items { get; set; } = [];
}
