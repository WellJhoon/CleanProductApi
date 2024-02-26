using CleanVentor.Aplication.Interfaces;
using CleanVentor.Aplication.Service;
using CleanVentor.Infraestructure.Context;
using CleanVentor.Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//register Configuration
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Add DbService
builder.Services.AddDbContext<ProductDbcontext>(opt => opt.UseSqlServer(configuration.GetConnectionString("connection"),
    b => b.MigrationsAssembly("CleanVentor.API")));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

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
