using Catabase.Application.Interfaces;
using Catabase.Domain.Entities;
using Catabase.Domain.UseCases;

namespace Catabase.Application.Services;

public class CatSearchService(ICatRepository catRepository) : ICatSearch
{
	private readonly ICatRepository _catRepository = catRepository;

	public async Task<IEnumerable<Cat>> GetAllCatsAsync(CancellationToken ct = default)
	{
		var cats = await _catRepository.GetAllCatsAsync(ct);

		return cats;
	}

	public Task<Cat?> GetCatAsync(int id, CancellationToken ct = default)
	{
		throw new NotImplementedException();
	}
}
