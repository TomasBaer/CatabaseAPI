namespace Catabase.Domain.UseCases;

public interface ICatRegistration
{
	Task RegisterCatAsync(string name, string breed, string color, int age);
	Task UpdateCatAsync(int id, string name, string breed, string color, int age);
}
