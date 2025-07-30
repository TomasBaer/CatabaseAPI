using Catabase.Api.Api.Cats.Create;
using Catabase.Application.Requests;
using Catabase.Domain.Enums;
using Catabase.Domain.UseCases;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace Catabase.Api.UnitTests;

public class CreateCatTests
{
	private readonly ICreateCatService _createCatService;

	public CreateCatTests()
	{
		var registrationService = Substitute.For<ICatRegistration>();
		registrationService.RegisterCatAsync(Arg.Any<string>(), Arg.Any<Breed>(), Arg.Any<CoatColor>(), Arg.Any<int>(), Arg.Any<CancellationToken>())
			.Returns(callInfo =>
			{
				var ct = callInfo.ArgAt<CancellationToken>(4);
				ct.ThrowIfCancellationRequested();
				return Task.FromResult(1);
			});

		_createCatService = new CreateCatService(registrationService);
	}

	[Fact]
	public async Task CreateCat()
	{
		var request = new CreateCatRequest
		{
			Name = "Tubby",
			Breed = Breed.Unknown,
			PrimaryColor = CoatColor.Black,
			Age = 10
		};

		var id = await _createCatService.CreateCatAsync(request);

		Assert.Equal(1, id);
	}

	[Fact]
	public async Task CreateCat_NullRequest_ThrowsArgumentNullException()
	{
		await Assert.ThrowsAsync<ArgumentNullException>(() => _createCatService.CreateCatAsync(null!));
	}

	[Fact]
	public async Task CreateCat_WithSecondaryColor_ReturnsId()
	{
		var request = new CreateCatRequest
		{
			Name = "Mittens",
			Breed = Breed.Unknown,
			PrimaryColor = CoatColor.White,
			SecondaryColor = CoatColor.Black,
			Age = 2
		};

		var id = await _createCatService.CreateCatAsync(request);

		Assert.Equal(1, id);
	}

	[Fact]
	public async Task CreateCat_MissingName_ThrowsArgumentException()
	{
		var request = new CreateCatRequest
		{
			Name = "",
			Breed = Breed.Unknown,
			PrimaryColor = CoatColor.Black,
			Age = 3
		};

		await Assert.ThrowsAsync<ArgumentException>(() => _createCatService.CreateCatAsync(request));
	}

	[Theory]
	[InlineData(Breed.Siamese)]
	[InlineData(Breed.Persian)]
	[InlineData(Breed.Unknown)]
	public async Task CreateCat_VariousBreeds_ReturnsId(Breed breed)
	{
		var request = new CreateCatRequest
		{
			Name = "Whiskers",
			Breed = breed,
			PrimaryColor = CoatColor.White,
			Age = 4
		};

		var id = await _createCatService.CreateCatAsync(request);

		Assert.Equal(1, id);
	}

	[Theory]
	[InlineData(CoatColor.Black)]
	[InlineData(CoatColor.White)]
	[InlineData(CoatColor.Tabby)]
	public async Task CreateCat_VariousPrimaryColors_ReturnsId(CoatColor color)
	{
		var request = new CreateCatRequest
		{
			Name = "Shadow",
			Breed = Breed.Persian,
			PrimaryColor = color,
			Age = 5
		};

		var id = await _createCatService.CreateCatAsync(request);

		Assert.Equal(1, id);
	}

	[Fact]
	public async Task CreateCat_NegativeAge_ThrowsArgumentOutOfRangeException()
	{
		var request = new CreateCatRequest
		{
			Name = "Kit",
			Breed = Breed.Persian,
			PrimaryColor = CoatColor.White,
			Age = -1
		};

		await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => _createCatService.CreateCatAsync(request));
	}

	[Fact]
	public async Task CreateCat_ZeroAge_ReturnsId()
	{
		var request = new CreateCatRequest
		{
			Name = "Zero",
			Breed = Breed.Persian,
			PrimaryColor = CoatColor.White,
			Age = 0
		};

		var id = await _createCatService.CreateCatAsync(request);

		Assert.Equal(1, id);
	}

	[Fact]
	public async Task CreateCat_RegistrationServiceThrows_PropagatesException()
	{
		var registrationService = Substitute.For<ICatRegistration>();
		registrationService.RegisterCatAsync(Arg.Any<string>(), Arg.Any<Breed>(), Arg.Any<CoatColor>(), Arg.Any<int>())
			.Throws(new InvalidOperationException("Registration failed"));

		var createCatService = new CreateCatService(registrationService);

		var request = new CreateCatRequest
		{
			Name = "ErrorCat",
			Breed = Breed.Persian,
			PrimaryColor = CoatColor.White,
			Age = 2
		};

		await Assert.ThrowsAsync<InvalidOperationException>(() => createCatService.CreateCatAsync(request));
	}

	[Fact]
	public async Task CreateCat_CancellationTokenCancelled_ThrowsOperationCanceledException()
	{
		var cts = new CancellationTokenSource();
		cts.Cancel();

		var request = new CreateCatRequest
		{
			Name = "Cancelled",
			Breed = Breed.Persian,
			PrimaryColor = CoatColor.White,
			Age = 2
		};

		await Assert.ThrowsAsync<OperationCanceledException>(() => _createCatService.CreateCatAsync(request, cts.Token));
	}
}
