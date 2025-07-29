using Catabase.Domain.Enums;

namespace Catabase.Application.Responses;

public class GetCatResponse
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public Breed Breed { get; set; }
	public int Age { get; set; }
	public Color PrimaryColor { get; set; }
}
