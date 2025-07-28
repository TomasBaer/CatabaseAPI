using CatDatabase.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatDatabase.Infrastructure;

public class CatContext : DbContext
{
	DbSet<Cat> Cats { get; set; } = null!;
}
