using ECommerse.Common.Interface;
using ECommerse.Common.Logic;
using ECommerse.Infrastracture.Interface;
using ECommerse.Infrastracture.Logic;

using Microsoft.AspNetCore.Mvc;

namespace ECommerse.API.Extections
{
    public static class ApplicationServiceExtentions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<IBasketRepository,BasketRepository>();
            services.AddScoped(typeof(IGenaricRepository<>),typeof(GenaricRepository<>));
            
            services.Configure<ApiBehaviorOptions>(options=>
            {
               /* options.InvalidModelStateResponseFactory=actionContext =>
                {
                    var error=actionContext.ModelState
                    .Where(e=>e.Value.Errors.Count>0)
                    .SelectMany(e=>e.Value.Errors)
                    .Select(e=>e.ErrorMessage).ToArray();

                   // var errorResponse=new ApiValidationErrorResponse

                
                };*/
            });
            return services;
        }

    }
}