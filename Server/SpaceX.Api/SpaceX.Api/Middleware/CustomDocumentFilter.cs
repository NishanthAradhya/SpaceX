using Microsoft.OpenApi.Models;
using SpaceX.Api.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SpaceX.Api.Middleware
{
    public class CustomDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            context.SchemaGenerator.GenerateSchema(typeof(LaunchModel), context.SchemaRepository);
        }
    }
}
