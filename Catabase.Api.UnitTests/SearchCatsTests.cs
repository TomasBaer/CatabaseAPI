using Catabase.Api.Api.Cats.Search;
using Catabase.Application.Responses;
using Catabase.Domain.Entities;
using Catabase.Domain.Enums;
using Catabase.Domain.Responses;
using Catabase.Domain.UseCases;
using NSubstitute;

namespace Catabase.Api.UnitTests;

public class SearchCatsTests
{
	private readonly ISearchCatsService _searchCatsService;
	public SearchCatsTests()
	{
		var searchResults = new CatSearchResponse
		{
			TotalCount = 2,
			Items = new List<Cat>
			{
				new Cat
			{
				Id = 1,
				Name = "Whiskers",
				Breed = Breed.Siamese,
				PrimaryColor = CoatColor.Black,
				Age = 3
			},
			new Cat
			{
				Id = 2,
				Name = "Mittens",
				Breed = Breed.Persian,
				PrimaryColor = CoatColor.White,
				Age = 5
			}
			}
		};

		var catSearchService = Substitute.For<ICatSearch>();
		catSearchService.SearchCatsAsync(Arg.Any<string>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<CancellationToken>())
			.Returns(callInfo =>
			{
				var ct = callInfo.ArgAt<CancellationToken>(3);
				ct.ThrowIfCancellationRequested();
				return Task.FromResult((ISearchResponse<Cat>)searchResults);
			});

		_searchCatsService = new SearchCatsService(catSearchService);
	}

	[Fact]
	public async Task SearchCatsAsync_ReturnsResults()
	{
		var result = await _searchCatsService.SearchCatsAsync("any", 1, 10, CancellationToken.None);

		Assert.NotNull(result);
		Assert.Equal(2, result.TotalCount);
		Assert.Collection(result.Items,
			item => Assert.Equal("Whiskers", item.Name),
			item => Assert.Equal("Mittens", item.Name));
	}

	[Fact]
	public async Task SearchCatsAsync_ReturnsEmpty_WhenNoResults()
	{
		// Arrange
		var catSearchService = Substitute.For<ICatSearch>();
		catSearchService.SearchCatsAsync(Arg.Any<string>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<CancellationToken>())
			.Returns(Task.FromResult<ISearchResponse<Cat>>(new CatSearchResponse { TotalCount = 0, Items = new List<Cat>() }));

		var searchCatsService = new SearchCatsService(catSearchService);

		// Act
		var result = await searchCatsService.SearchCatsAsync("none", 1, 10, CancellationToken.None);

		// Assert
		Assert.NotNull(result);
		Assert.Empty(result.Items);
		Assert.Equal(0, result.TotalCount);
	}

	[Fact]
	public async Task SearchCatsAsync_Throws_WhenCancelled()
	{
		var cts = new CancellationTokenSource();
		cts.Cancel();

		await Assert.ThrowsAsync<OperationCanceledException>(() =>
			_searchCatsService.SearchCatsAsync("any", 1, 10, cts.Token));
	}
}
