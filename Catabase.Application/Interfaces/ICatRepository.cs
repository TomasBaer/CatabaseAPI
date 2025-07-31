using Catabase.Domain.Entities;

namespace Catabase.Application.Interfaces;

public interface ICatRepository
{
	Task<int> CreateCatAsync(Cat cat, CancellationToken ct = default);
	Task<Cat?> GetCatByIdAsync(int id, CancellationToken ct = default);
	Task<(IEnumerable<Cat>, int)> SearchCatsAsync(string query, int page, int pageSize, CancellationToken ct = default);
	Task<int> UpdateCatAsync(Cat cat, CancellationToken ct = default);
	Task DeleteCatAsync(int id, CancellationToken ct = default);
}
