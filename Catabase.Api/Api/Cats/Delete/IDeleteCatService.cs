namespace Catabase.Api.Api.Cats.Delete;

public interface IDeleteCatService
{
	Task HardDeleteCatAsync(int id, CancellationToken ct = default);
	Task SoftDeleteCatAsync(int id, CancellationToken ct = default);
}
