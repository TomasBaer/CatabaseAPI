using Catabase.Application.Interfaces;
using Catabase.Domain.Entities;
using Catabase.Domain.Enums;
using Catabase.Domain.UseCases;

namespace Catabase.Application.Services;

public class CatRegistrationService(ICatRepository repository) : ICatRegistration
{
	private readonly ICatRepository _repository = repository;

	public async Task<int> RegisterCatAsync(string name, Breed breed, CoatColor primaryColor, int? age, CancellationToken ct = default)
	{
		var cat = new Cat()
		{
			Name = name,
			Breed = breed,
			PrimaryColor = primaryColor,
			Age = age
		};

		var catId = await _repository.CreateCatAsync(cat);

		return catId;
	}

	public async Task<int> UpdateCatAsync(int id, string name, Breed breed, CoatColor primaryColor, CoatColor? secondaryColor, int? age, bool deleted, CancellationToken ct = default)
	{
		var cat = new Cat()
		{
			Id = id,
			Name = name,
			Breed = breed,
			PrimaryColor = primaryColor,
			SecondaryColor = secondaryColor,
			Age = age,
			Deleted = deleted
		};

		var catId = await _repository.UpdateCatAsync(cat, ct);

		return catId;
	}

	public async Task SoftDeleteCatAsync(int id, CancellationToken ct = default)
	{
		var cat = await _repository.GetCatByIdAsync(id);
		if (cat == null)
		{
			throw new KeyNotFoundException($"Cat with ID {id} not found.");
		}

		cat.Deleted = true;
		await _repository.UpdateCatAsync(cat, ct);
	}

	public async Task HardDeleteCatAsync(int id, CancellationToken ct = default)
	{
		await _repository.DeleteCatAsync(id, ct);
	}
}
