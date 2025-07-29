using Catabase.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catabase.Infrastructure;

public class CatContext : DbContext
{
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
	}

	DbSet<Cat> Cats { get; set; }
}
