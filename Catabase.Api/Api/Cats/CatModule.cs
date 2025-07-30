using Carter;
using Catabase.Api.Api.Cats.Create;
using Catabase.Api.Api.Cats.Get;
using Catabase.Api.Api.Cats.Search;
using Catabase.Application.Requests;
using Catabase.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Catabase.Api.Api.Cats;

public class CatModule : CarterModule
{
	public CatModule() : base("/cats")
	{
	}

	public override void AddRoutes(IEndpointRouteBuilder app)
	{
		// GET
		app.MapGet("/{Id:int}", async (
			int id,
			[FromServices] IGetCatsService service,
			CancellationToken ct) =>
		{
			try
			{
				var cat = await service.GetCatAsync(id, ct);
				return cat != null ? Results.Ok(cat) : Results.NotFound();
			}
			catch (Exception)
			{
				return Results.Problem("There was a problem fetching the cat.", statusCode: 500);
			}
		})
		.Produces<GetCatResponse>(StatusCodes.Status200OK)
		.Produces(StatusCodes.Status404NotFound)
		.Produces(StatusCodes.Status500InternalServerError);

		// SEARCH
		app.MapGet("/", async (
			string? query, int page, int pageSize,
			[FromServices] ISearchCatsService service,
			CancellationToken ct) =>
		{
			try
			{
				var searchResults = await service.SearchCatsAsync(query, page, pageSize);
				return Results.Ok(searchResults);
			}
			catch (Exception)
			{
				return Results.Problem("An error occurred while searching for cats.", statusCode: 500);
			}
		})
		.Produces<GetCatResponse>(StatusCodes.Status200OK)
		.Produces(StatusCodes.Status500InternalServerError); ;

		// POST
		app.MapPost("/", async ([FromServices] ICreateCatService service, CreateCatRequest request, CancellationToken ct) =>
		{
			try
			{
				var id = await service.CreateCatAsync(request, ct);
				return Results.Created($"/cats/{id}", id);
			}
			catch (Exception)
			{
				return Results.Problem("An error occurred while creating the cat.", statusCode: 500);
			}
		})
		.Produces<GetCatResponse>(StatusCodes.Status200OK)
		.Produces(StatusCodes.Status500InternalServerError);
	}
}
