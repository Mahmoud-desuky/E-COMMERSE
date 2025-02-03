using Back.Infrastracture.Data;
using Back.Infrastracture.Interface;
using Back.Infrastracture.Logic;
using Back.Repository.Interface;
using Back.Repository.Logic;
using Microsoft.EntityFrameworkCore;

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
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
