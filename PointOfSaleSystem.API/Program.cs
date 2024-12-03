using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PointOfSaleSystem.API.Context;
using PointOfSaleSystem.API.Models.Entities;
using PointOfSaleSystem.API.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PointOfSaleSystemContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<CompanyEntity, Company>();
    cfg.CreateMap<Company, CompanyEntity>();
});

builder.Services.AddSingleton(mapperConfig.CreateMapper());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
