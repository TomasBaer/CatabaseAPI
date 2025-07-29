using Catabase.Domain.Enums;

namespace Catabase.Domain.UseCases;

public interface ICatRegistration
{
	Task<int> RegisterCatAsync(string name, Breed breed, Color primaryColor, int age);
	Task UpdateCatAsync(int id, string name, Breed breed, Color primaryColor, int age);
}
