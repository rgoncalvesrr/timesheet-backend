using Asp.Versioning;

namespace Timesheet.Api.Common;

public static class BuilderExtension
{
    extension(WebApplicationBuilder builder)
    {
        public void AddVersioning()
        {
            // Add services to the container.
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true; // Retorna headers com versões suportadas (api-supported-versions)

                // Combina leitura de versão: Pela URL (api/v1/...) OU Header (X-Api-Version) OU QueryString (?api-version=1.0)
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader(),
                    new HeaderApiVersionReader("X-Api-Version"),
                    new QueryStringApiVersionReader("api-version"));
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        }
    }
}