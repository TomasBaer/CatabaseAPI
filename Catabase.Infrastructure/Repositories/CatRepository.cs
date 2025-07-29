using Catabase.Domain.Entities;

namespace Catabase.Infrastructure.Repositories;

public class CatRepository : ICatRepository
{


	public Task AddCatAsync(Cat cat)
	{
		throw new NotImplementedException();
	}

	public Task DeleteCatAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<Cat>> GetAllCatsAsync()
	{
		throw new NotImplementedException();
	}

	public Task<Cat?> GetCatByIdAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Task UpdateCatAsync(Cat cat)
	{
		throw new NotImplementedException();
	}
}
