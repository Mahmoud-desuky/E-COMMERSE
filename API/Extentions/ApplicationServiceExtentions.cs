using Back.Infrastracture.Interface;
using Back.Infrastracture.Logic;
using Back.Repository.Interface;
using Back.Repository.Logic;
using Microsoft.AspNetCore.Mvc;

namespace Back.API.Extections
{
    public static class ApplicationServiceExtentions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<IProduct,ProductLogic>();
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