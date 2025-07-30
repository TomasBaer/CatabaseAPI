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

	public async Task<(IEnumerable<Cat>, int)> SearchCatsAsync(string query, int page, int pageSize, CancellationToken ct = default)
	{
		var catsQuery = (IQueryable<Cat>)_db.Cats;

		if (!string.IsNullOrEmpty(query))
		{
			catsQuery = catsQuery.Where(cat => cat.Name.Contains(query));
		}
							

		var totalCount = await catsQuery.CountAsync(ct);

		var cats = await catsQuery
							.Skip(page * pageSize)
							.Take(pageSize)
							.ToArrayAsync(ct);

		return (cats, totalCount);
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
