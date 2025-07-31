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

	public async Task<int> UpdateCatAsync(Cat update, CancellationToken ct = default)
	{
		var cat = await _db.Cats.FirstOrDefaultAsync(cat => cat.Id == update.Id, ct);
		if (cat == null)
		{
			throw new KeyNotFoundException($"Cat with ID {update.Id} not found.");
		}

		cat.Name = update.Name;
		cat.Breed = update.Breed;
		cat.PrimaryColor = update.PrimaryColor;
		cat.SecondaryColor = update.SecondaryColor;
		cat.Age = update.Age;
		cat.Deleted = update.Deleted;

		_db.Cats.Update(cat);
		_ = await _db.SaveChangesAsync(ct);

		return cat.Id;
	}

	public async Task DeleteCatAsync(int id, CancellationToken ct = default)
	{
		var cat = await _db.Cats.FirstOrDefaultAsync(cat => cat.Id == id, ct);
		if (cat == null)
		{
			throw new KeyNotFoundException($"Cat with ID {id} not found.");
		}

		_db.Cats.Remove(cat);
		_ = await _db.SaveChangesAsync(ct);
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

	public async Task<Cat?> GetCatByIdAsync(int id, CancellationToken ct = default)
	{
		var cat = await _db.Cats.FirstOrDefaultAsync(cat => cat.Id == id, ct);

		return cat;
	}

	
}
