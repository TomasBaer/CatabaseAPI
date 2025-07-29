using Catabase.Domain.Entities;

namespace Catabase.Domain.UseCases;

public interface ICatSearch
{
	Task<IEnumerable<Cat>> GetAllCatsAsync(CancellationToken ct = default);
	Task<Cat?> GetCatAsync(int id, CancellationToken ct = default);
}
