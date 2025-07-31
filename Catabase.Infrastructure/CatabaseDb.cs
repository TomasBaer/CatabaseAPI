using Catabase.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Catabase.Infrastructure;

public interface ICatabaseDb
{
	DbSet<Cat> Cats { get; set; }

	Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

public class CatabaseDb(DbContextOptions<CatabaseDb> options) : DbContext(options), ICatabaseDb
{
	public DbSet<Cat> Cats { get; set; }	
}
