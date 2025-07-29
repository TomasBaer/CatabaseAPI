using Catabase.Application.Requests;
using Catabase.Domain.UseCases;

namespace Catabase.Api.Api.Cats.Create;

public class CreateCatService(ICatRegistration catRegistrationService) : ICreateCatService
{
	private readonly ICatRegistration _catRegistrationService = catRegistrationService;

	public async Task<int> CreateCatAsync(CreateCatRequest request, CancellationToken ct = default)
	{
		var id = await _catRegistrationService.RegisterCatAsync(request.Name, request.Breed, request.PrimaryColor, request.Age);

		return id;
	}
}
