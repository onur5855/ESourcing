using ESourcing.Products.Data.Interfaces;
using ESourcing.Products.Data;
using ESourcing.Products.Repository.Interfaces;
using ESourcing.Products.Repository;
using ESourcing.Products.Settings;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.Configure<ProductDatabaseSettings>(builder.Configuration.GetSection(nameof(ProductDatabaseSettings)));
builder.Services.AddSingleton<IProductDatabaseSettings>(ps => ps.GetRequiredService<IOptions<ProductDatabaseSettings>>().Value);

builder.Services.AddScoped<IProductContext, ProductContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSwaggerGen(a =>
//{
//    a.SwaggerDoc("v1", new OpenApiInfo
//    {
//        Title = "EsourcingProducts",
//        Version = "v1"
//    });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseSwaggerUI(a => a.SwaggerEndpoint("/swagger/v1/swagger.json", "EsourcingProducts v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
