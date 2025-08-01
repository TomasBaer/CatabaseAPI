using Catabase.Application.Interfaces;
using Catabase.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Catabase.Infrastructure.Repositories;

public class CatRepository(ICatabaseDb db, ILogger<CatRepository> logger) : ICatRepository
{
	private readonly ICatabaseDb _db = db;
	private readonly ILogger<CatRepository> _logger = logger;

	public async Task<int> CreateCatAsync(Cat cat, CancellationToken ct = default)
	{
		_db.Cats.Add(cat);
		await _db.SaveChangesAsync(ct);

		_logger.LogInformation("CREATE cat {cat.Id} succeeded.", cat.Id);

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

		_logger.LogInformation("UPDATE cat {cat.Id} succeeded.", cat.Id);

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

		_logger.LogInformation("DELETE cat {cat.Id} succeeded.", cat.Id);
	}

	public async Task<(IEnumerable<Cat>, int)> SearchCatsAsync(string query, int page, int pageSize, CancellationToken ct = default)
	{
		var catsQuery = _db.Cats.Where(cat => !cat.Deleted);

		if (!string.IsNullOrEmpty(query))
		{
			catsQuery = catsQuery.Where(cat => cat.Name.Contains(query));
		}
							

		var totalCount = await catsQuery.CountAsync(ct);

		var cats = await catsQuery
							.Skip(page * pageSize)
							.Take(pageSize)
							.ToArrayAsync(ct);

		_logger.LogInformation("SEARCH cats succeeded.");

		return (cats, totalCount);
	}

	public async Task<Cat?> GetCatByIdAsync(int id, CancellationToken ct = default)
	{
		var cat = await _db.Cats.FirstOrDefaultAsync(cat => cat.Id == id, ct);

		_logger.LogInformation("GET cat succeeded.");

		return cat;
	}	
}
