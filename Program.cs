using System.Reflection;
using Back.API.Middleware;
using Back.Infrastracture.Data;
using Back.Infrastracture.Interface;
using Back.Infrastracture.Logic;
using Back.Infrastructure.Identity;
using Back.Repository.Interface;
using Back.Repository.Logic;
using E_COMMERSE.API.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IProduct, ProductLogic>();
builder.Services.AddTransient<IBasketRepository, BasketRepository>();




// Add Scope of GenaricRepository
builder.Services.AddScoped(typeof(IGenaricRepository<>),typeof(GenaricRepository<>));


// Add services to the container.
builder.Services.AddDbContext<StoreContext>(x=>
 x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<ApplicationIdentityDbContext>(x=>
   x.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));
   
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


 builder.Services.Configure<ApiBehaviorOptions>(options=>
    {
         options.InvalidModelStateResponseFactory=ActionContext =>
          {
             var errors=ActionContext.ModelState
                    .Where(e=>e.Value.Errors.Count>0)
                    .SelectMany(x=>x.Value.Errors)
                    .Select(x=>x.ErrorMessage).ToArray();

           /*  var errorResponse=new ApiValidationErrorResponse
                   {
                          Errors=errors
                   };
*/
             return new BadRequestObjectResult(errors);
         };

    });
 builder.Services.AddSwaggerGen(c =>
    {
      c.SwaggerDoc("v1", new OpenApiInfo { Title = "ECommerce Application", Version = "v1" });
    });
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseDeveloperExceptionPage();
}
builder.Services.AddIdentityServices(builder.Configuration);
app.UseStatusCodePagesWithReExecute("/errors/{0}");
app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
