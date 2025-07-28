namespace CatDatabase.Domain.Entities;

public class Cat
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public string Breed { get; set; } = string.Empty;
	public string Color { get; set; } = string.Empty;
	public int Age { get; set; }
}
