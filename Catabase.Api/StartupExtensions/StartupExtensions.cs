using Catabase.Api.Api.Cats.Create;
using Catabase.Api.Api.Cats.Delete;
using Catabase.Api.Api.Cats.Search;
using Catabase.Api.Config;
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
		services.AddScoped<ISearchCatsService, SearchCatsService>();
		services.AddScoped<IDeleteCatService, DeleteCatService>();

		return services;
	}

	public static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{
		services.AddScoped<ICatRegistration, CatRegistrationService>();
		services.AddScoped<ICatSearch, CatSearchService>();

		return services;
	}

	public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, ConnectionStrings connectionStrings)
	{
		services.AddScoped<ICatRepository, CatRepository>();

		services.AddDbContext<ICatabaseDb, CatabaseDb>(options =>
		{
			options.UseSqlServer(connectionStrings.CatabaseDb);
			options.EnableSensitiveDataLogging();
		});

		return services;
	}
}
