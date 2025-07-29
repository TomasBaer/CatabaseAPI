namespace Catabase.Api.Api.Cats.Get;

public interface IGetCatsService
{
	Task<GetCatResponse?> GetCatAsync(int id, CancellationToken ct = default);
	Task<IEnumerable<GetCatResponse>> GetAllCatsAsync(CancellationToken ct = default);
}
