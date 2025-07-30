using Catabase.Domain.Enums;

namespace Catabase.Domain.UseCases;

public interface ICatRegistration
{
	Task<int> RegisterCatAsync(string name, Breed breed, CoatColor primaryColor, int? age, CancellationToken ct = default);
	Task UpdateCatAsync(int id, string name, Breed breed, CoatColor primaryColor, int? age, CancellationToken ct = default);
}
