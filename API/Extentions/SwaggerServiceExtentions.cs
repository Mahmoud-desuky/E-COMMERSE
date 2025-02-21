using Microsoft.OpenApi.Models;

namespace Back.API.Extections
{
    public static class SwaggerServiceExtentions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)  
        {
            services.AddSwaggerGen(c =>
            {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "ECommerce Application", Version = "v1" });
            });
            return services ;
        }
    }
}