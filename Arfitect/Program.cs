using Product.API.Entity;
using Microsoft.EntityFrameworkCore;
using Product.API.Business.Interfaces;
using Product.API.Business;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductService, ProductManager>();
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ProductApiDbContext>(options => options.UseMySql(connectionString,
        ServerVersion.AutoDetect(connectionString)));

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

