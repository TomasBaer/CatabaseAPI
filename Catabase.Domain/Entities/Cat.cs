using Catabase.Domain.Enums;

namespace Catabase.Domain.Entities;

public class Cat
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public Breed Breed { get; set; }
	public CoatColor PrimaryColor { get; set; }
	public CoatColor? SecondaryColor { get; set; }
	public int? Age { get; set; }
}
