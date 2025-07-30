//using Catabase.Application.Responses;
//using Catabase.Domain.UseCases;

//namespace Catabase.Api.Api.Cats.Get;

//public class GetCatsService(ICatSearch catSearchService) : IGetCatsService
//{
//	private readonly ICatSearch _catSearchService = catSearchService;

//	public async Task<IEnumerable<GetCatResponse>> GetAllCatsAsync(CancellationToken ct = default)
//	{
//		var cats = await _catSearchService.SearchCatsAsync(ct);

//		var response = cats.Select(cat => new GetCatResponse
//		{
//			Id = cat.Id,
//			Name = cat.Name,
//			Breed = cat.Breed,
//			Age = cat.Age,
//			PrimaryColor = cat.PrimaryColor
//		});

//		return response;
//	}

//	public Task<GetCatResponse?> GetCatAsync(int id, CancellationToken ct = default)
//	{
//		throw new NotImplementedException();
//	}
//}
