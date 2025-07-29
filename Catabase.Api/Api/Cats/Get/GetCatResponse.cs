namespace Catabase.Api.Api.Cats.Get;

public class GetCatResponse
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public string Breed { get; set; } = string.Empty;
	public int Age { get; set; }
	public string Color { get; set; } = string.Empty;
}
