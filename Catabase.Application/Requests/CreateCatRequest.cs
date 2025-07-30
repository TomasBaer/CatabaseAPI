using Catabase.Domain.Enums;

namespace Catabase.Application.Requests;

public class CreateCatRequest
{
	public required string Name { get; set; } = string.Empty;
	public Breed Breed { get; set; } = Breed.Unknown;
	public int? Age { get; set; }
	public CoatColor PrimaryColor { get; set; } = CoatColor.Unknown;
	public CoatColor? SecondaryColor { get; set; }
}
