using ESourcing.sourcing.Data;
using ESourcing.sourcing.Data.Interfaces;
using ESourcing.sourcing.Repository;
using ESourcing.sourcing.Repository.Interfaces;
using ESourcing.sourcing.Settings;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

#region json baðlantý configurations and life döndüðüsü 
builder.Services.Configure<SourcingDatabaseSettings>(builder.Configuration.GetSection(nameof(SourcingDatabaseSettings)));
builder.Services.AddSingleton<ISourcingDatabaseSettings>(ps => ps.GetRequiredService<IOptions<SourcingDatabaseSettings>>().Value);
#endregion
#region Life 
builder.Services.AddScoped<ISourcingContext,SourcingContext>();
builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();
builder.Services.AddScoped<IBidRepository, BidRepository>();
#endregion

builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(a =>
{
    a.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Esourcing.Sourcing",
        Version = "v1"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
   // app.UseSwaggerUI();
    app.UseSwaggerUI(a => a.SwaggerEndpoint("/swagger/v1/swagger.json", "Sourcing Api v1"));    
}

app.UseAuthorization();

app.MapControllers();

app.Run();
