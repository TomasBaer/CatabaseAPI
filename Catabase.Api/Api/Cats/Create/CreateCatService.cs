using Catabase.Application.Requests;
using Catabase.Domain.UseCases;

namespace Catabase.Api.Api.Cats.Create;

public class CreateCatService(ICatRegistration catRegistrationService) : ICreateCatService
{
	private readonly ICatRegistration _catRegistrationService = catRegistrationService;

	public async Task<int> CreateCatAsync(CreateCatRequest request, CancellationToken ct = default)
	{
		if (request == null)
		{
			throw new ArgumentNullException(nameof(request), "Request cannot be null.");
		}

		if (string.IsNullOrWhiteSpace(request.Name))
		{
			throw new ArgumentException("Cat name cannot be null or empty.");
		}

		if (request.Age.HasValue && request.Age < 0)
		{
			throw new ArgumentOutOfRangeException("Age must be a positive integer.");
		}

		var id = await _catRegistrationService.RegisterCatAsync(request.Name, request.Breed, request.PrimaryColor, request.Age, ct);

		return id;
	}
}
