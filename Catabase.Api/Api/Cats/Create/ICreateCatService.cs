namespace Catabase.Api.Api.Cats.Create;

public interface ICreateCatService
{
	Task<int> CreateCatAsync(CreateCatRequest request, CancellationToken ct = default);
}
