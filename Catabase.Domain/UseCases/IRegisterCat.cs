namespace CatDatabase.Domain.UseCases;

public interface IRegisterCat
{
	Task RegisterCatAsync(string name, string breed, string color, int age);
}
