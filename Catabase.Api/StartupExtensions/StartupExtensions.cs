using Catabase.Api.Api.Cats.Create;
using Catabase.Api.Api.Cats.Get;
using Catabase.Application.Interfaces;
using Catabase.Application.Services;
using Catabase.Domain.UseCases;
using Catabase.Infrastructure;
using Catabase.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Catabase.Api.StartupExtensions;

public static class StartupExtensions
{
	public static IServiceCollection AddApiServices(this IServiceCollection services)
	{
		services.AddScoped<ICreateCatService, CreateCatService>();
		services.AddScoped<IGetCatsService, GetCatsService>();

		return services;
	}

	public static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{
		services.AddScoped<ICatRegistration, CatRegistrationService>();
		services.AddScoped<ICatSearch, CatSearchService>();

		return services;
	}

	public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
	{
		services.AddScoped<ICatRepository, CatRepository>();

		services.AddDbContext<ICatabaseDb, CatabaseDb>(options =>
		{
			options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
			options.EnableSensitiveDataLogging();
		});

		return services;
	}
}
