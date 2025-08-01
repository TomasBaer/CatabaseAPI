using Carter;
using Catabase.Api.Config;
using Catabase.Api.StartupExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddOpenApiDocument();
builder.Services.AddCarter();

var connectionStrings = builder.Configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>() ?? new ConnectionStrings();

builder.Services.AddInfrastructureServices(connectionStrings);
builder.Services.AddApplicationServices();
builder.Services.AddApiServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
	app.UseOpenApi();
	app.UseSwaggerUi();
}

app.MapCarter();

app.UseHttpsRedirection();

app.Run();
