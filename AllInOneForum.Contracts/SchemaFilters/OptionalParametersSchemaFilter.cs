using AllInOneForum.Contracts.Atributes;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AllInOneForum.Contracts.SchemaFilters
{
    public class OptionalParametersSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.MemberInfo.GetCustomAttributes(typeof(OptionalParameterAttribute), true).Any())
            {
                schema.Nullable = true;
            }
        }
    }
}
