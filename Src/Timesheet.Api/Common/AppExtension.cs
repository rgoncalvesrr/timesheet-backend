using Scalar.AspNetCore;

namespace Timesheet.Api.Common;

public static class AppExtension
{
    extension(WebApplication app)
    {
        public void UseApiDocumentation()
        {
            // Gera os endpoints JSON do OpenAPI (/openapi/v1.json e /openapi/v2.json)
            app.MapOpenApi();

            // Adiciona a interface visual do Scalar (em http://localhost:5000/scalar/v1)
            // O Scalar é a alternativa moderna ao Swagger UI no .NET 9/10
            app.MapScalarApiReference(options =>
            {
                options.Title = "Documentação da API";
                options.Theme = ScalarTheme.DeepSpace;
                options.DynamicBaseServerUrl = true;
                options.DefaultHttpClient = new KeyValuePair<ScalarTarget, ScalarClient>(ScalarTarget.CSharp, ScalarClient.HttpClient);
            });
        }
    }
}