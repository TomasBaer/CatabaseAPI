using Catabase.Domain.Enums;

namespace Catabase.Api.Api.Cats.Create;

public class CreateCatRequest
{
	public required string Name { get; set; } = string.Empty;
	public Breed Breed { get; set; } = Breed.Unknown;
	public int Age { get; set; }
	public Color PrimaryColor { get; set; } = Color.Unknown;
	public Color? SecondaryColor { get; set; }
}
