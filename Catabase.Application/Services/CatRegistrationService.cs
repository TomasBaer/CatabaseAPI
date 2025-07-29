using Catabase.Domain.UseCases;

namespace Catabase.Application.Services;

public class CatRegistrationService : ICatRegistration
{
	public async Task RegisterCatAsync(string name, string breed, string color, int age)
	{
		throw new NotImplementedException();
	}

	public async Task UpdateCatAsync(int id, string name, string breed, string color, int age)
	{
		throw new NotImplementedException();
	}
}
