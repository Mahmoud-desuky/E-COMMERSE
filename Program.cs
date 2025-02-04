using System.Reflection;
using Back.API.Errors;
using Back.API.Middleware;
using Back.Infrastracture.Data;
using Back.Infrastracture.Interface;
using Back.Infrastracture.Logic;
using Back.Repository.Interface;
using Back.Repository.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IProduct, ProductLogic>();



// Add Scope of GenaricRepository
builder.Services.AddScoped(typeof(IGenaricRepository<>),typeof(GenaricRepository<>));


// Add services to the container.
builder.Services.AddDbContext<StoreContext>(x=>
 x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

 builder.Services.AddSwaggerGen(c =>
    {
      c.SwaggerDoc("v1", new OpenApiInfo { Title = "ECommerce Application", Version = "v1" });
    });

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();
app.UseStatusCodePagesWithReExecute("/errors/{0}");


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();


app.MapControllers();

app.Run();
