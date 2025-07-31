using Catabase.Domain.Enums;

namespace Catabase.Domain.UseCases;

public interface ICatRegistration
{
	Task<int> RegisterCatAsync(string name, Breed breed, CoatColor primaryColor, int? age, CancellationToken ct = default);
	Task<int> UpdateCatAsync(int id, string name, Breed breed, CoatColor primaryColor, CoatColor? secondaryColor, int? age, bool deleted, CancellationToken ct = default);
	Task HardDeleteCatAsync(int id, CancellationToken ct = default);
	Task SoftDeleteCatAsync(int id, CancellationToken ct = default);
}
