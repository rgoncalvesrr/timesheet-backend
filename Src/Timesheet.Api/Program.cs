using System.Text.Json.Serialization;
using Timesheet.Api.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseApiDocumentation();

app.UseHttpsRedirection();

app.MapGet("/",
        () => new HealthCheck(Timestamp: DateTime.UtcNow.ToLocalTime()))
    .WithName("GetHealth")
    .WithSummary("Obtém status da API")
    .WithDescription("Verificação de estado da API")
    .Produces<HealthCheck>(StatusCodes.Status200OK, contentType: "application/json");

app.Run();

public record HealthCheck(
    [property: JsonPropertyName("healthCheck")]
    DateTime Timestamp);