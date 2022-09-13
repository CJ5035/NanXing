using Microsoft.OpenApi.Models;

namespace CRMApi.Models.Entity
{
    internal class ApiKeyScheme : OpenApiSecurityScheme
    {
        public string Description { get; set; }
        public ParameterLocation In { get; set; }
        public SecuritySchemeType Type { get; set; }
    }
}