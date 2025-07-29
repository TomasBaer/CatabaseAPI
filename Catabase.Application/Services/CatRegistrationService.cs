using Catabase.Application.Interfaces;
using Catabase.Domain.Entities;
using Catabase.Domain.Enums;
using Catabase.Domain.UseCases;

namespace Catabase.Application.Services;

public class CatRegistrationService(ICatRepository repository) : ICatRegistration
{
	private readonly ICatRepository _repository = repository;

	public async Task<int> RegisterCatAsync(string name, Breed breed, Color primaryColor, int age)
	{
		var cat = new Cat()
		{
			Name = name,
			Breed = breed,
			PrimaryColor = primaryColor,
			Age = age
		};

		var id = await _repository.CreateCatAsync(cat);

		return id;
	}

	public Task UpdateCatAsync(int id, string name, Breed breed, Color primaryColor, int age)
	{
		throw new NotImplementedException();
	}
}
