
using Catabase.Domain.UseCases;

namespace Catabase.Api.Api.Cats.Delete;

public class DeleteCatService(ICatRegistration catRegistration) : IDeleteCatService
{
	private readonly ICatRegistration _catRegistrationService = catRegistration;

	public async Task HardDeleteCatAsync(int id, CancellationToken ct = default)
	{
		if (id <= 0)
		{
			throw new ArgumentOutOfRangeException(nameof(id), "Cat ID must be a positive integer.");
		}

		await _catRegistrationService.HardDeleteCatAsync(id, ct);
	}

	public async Task SoftDeleteCatAsync(int id, CancellationToken ct = default)
	{
		if (id <= 0)
		{
			throw new ArgumentOutOfRangeException(nameof(id), "Cat ID must be a positive integer.");
		}

		await _catRegistrationService.SoftDeleteCatAsync(id, ct);
	}
}
