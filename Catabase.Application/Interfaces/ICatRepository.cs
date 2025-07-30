using Catabase.Domain.Entities;

namespace Catabase.Application.Interfaces;

public interface ICatRepository
{
	Task<int> CreateCatAsync(Cat cat, CancellationToken ct = default);
	Task<Cat?> GetCatByIdAsync(int id);
	Task<(IEnumerable<Cat>, int)> SearchCatsAsync(string query, int page, int pageSize, CancellationToken ct = default);
	Task UpdateCatAsync(Cat cat);
	Task DeleteCatAsync(int id);
}
