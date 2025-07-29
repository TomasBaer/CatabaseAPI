using Catabase.Domain.Entities;

namespace Catabase.Infrastructure.Repositories;

public interface ICatRepository
{
	Task AddCatAsync(Cat cat);
	Task<Cat?> GetCatByIdAsync(int id);
	Task<IEnumerable<Cat>> GetAllCatsAsync();
	Task UpdateCatAsync(Cat cat);
	Task DeleteCatAsync(int id);
}
