using Catabase.Api.Api.Cats.Delete;
using Catabase.Domain.UseCases;
using NSubstitute;

namespace Catabase.Api.UnitTests;

public class DeleteCatTests
{
	private readonly IDeleteCatService _deleteCatService;
	public DeleteCatTests()
	{
		var registrationService = Substitute.For<ICatRegistration>();
		registrationService.SoftDeleteCatAsync(Arg.Any<int>(), Arg.Any<CancellationToken>())
			.Returns(callInfo =>
			{
				var ct = callInfo.ArgAt<CancellationToken>(1);
				ct.ThrowIfCancellationRequested();
				return Task.CompletedTask;
			});

		registrationService.HardDeleteCatAsync(Arg.Any<int>(), Arg.Any<CancellationToken>())
			.Returns(callInfo =>
			{
				var ct = callInfo.ArgAt<CancellationToken>(1);
				ct.ThrowIfCancellationRequested();
				return Task.CompletedTask;
			});

		_deleteCatService = new DeleteCatService(registrationService);
	}

	[Fact]
	public async Task SoftDeleteCatAsync_DeletesCat()
	{
		await _deleteCatService.SoftDeleteCatAsync(1, CancellationToken.None);
	}

	[Fact]
	public async Task SoftDeleteCatAsync_Throws_WhenCancelled()
	{
		var cts = new CancellationTokenSource();
		cts.Cancel();
		await Assert.ThrowsAsync<OperationCanceledException>(() =>
			_deleteCatService.SoftDeleteCatAsync(1, cts.Token));
	}

	[Theory]
	[InlineData(0)]
	[InlineData(-1)]
	public async Task SoftDeleteCatAsync_Throws_OnInvalidId(int invalidId)
	{
		await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
			_deleteCatService.SoftDeleteCatAsync(invalidId, CancellationToken.None));
	}

	[Fact]
	public async Task HardDeleteCatAsync_DeletesCat()
	{
		await _deleteCatService.HardDeleteCatAsync(1, CancellationToken.None);
	}

	[Fact]
	public async Task HardDeleteCatAsync_Throws_WhenCancelled()
	{
		var cts = new CancellationTokenSource();
		cts.Cancel();

		await Assert.ThrowsAsync<OperationCanceledException>(() =>
			_deleteCatService.HardDeleteCatAsync(1, cts.Token));
	}

	[Theory]
	[InlineData(0)]
	[InlineData(-1)]
	public async Task HardDeleteCatAsync_Throws_OnInvalidId(int invalidId)
	{
		await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
			_deleteCatService.HardDeleteCatAsync(invalidId, CancellationToken.None));
	}
}
