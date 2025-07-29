using Catabase.Application.Interfaces;
using Catabase.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catabase.Infrastructure.Repositories;

public class CatRepository(ICatabaseDb db) : ICatRepository
{
	private readonly ICatabaseDb _db = db;

	public async Task<int> CreateCatAsync(Cat cat, CancellationToken ct = default)
	{
		_db.Cats.Add(cat);
		await _db.SaveChangesAsync(ct);

		return cat.Id;
	}

	public Task DeleteCatAsync(int id)
	{
		throw new NotImplementedException();
	}

	public async Task<IEnumerable<Cat>> GetAllCatsAsync(CancellationToken ct = default)
	{
		var cats = await _db.Cats.ToArrayAsync(ct);

		return cats;
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
