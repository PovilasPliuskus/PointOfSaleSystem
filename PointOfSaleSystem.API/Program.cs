using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PointOfSaleSystem.API.Context;
using PointOfSaleSystem.API.Models.Entities;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Repositories.Interfaces;
using PointOfSaleSystem.API.Repositories;
using PointOfSaleSystem.API.Services.Interfaces;
using PointOfSaleSystem.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PointOfSaleSystemContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<CompanyEntity, Company>();
    cfg.CreateMap<Company, CompanyEntity>();

    cfg.CreateMap<EstablishmentEntity, Establishment>();
    cfg.CreateMap<Establishment, EstablishmentEntity>();

    cfg.CreateMap<CompanyProductEntity, CompanyProduct>();
    cfg.CreateMap<CompanyProduct, CompanyProductEntity>();

    cfg.CreateMap<CompanyServiceEntity, PointOfSaleSystem.API.Models.CompanyService>();
    cfg.CreateMap<PointOfSaleSystem.API.Models.CompanyService, CompanyServiceEntity>();

    cfg.CreateMap<EmployeeEntity, Employee>();
    cfg.CreateMap<Employee, EmployeeEntity>();

    cfg.CreateMap<EstablishmentProductEntity, EstablishmentProduct>();
    cfg.CreateMap<EstablishmentProduct, EstablishmentProductEntity>();

    cfg.CreateMap<EstablishmentServiceEntity, EstablishmentService>();
    cfg.CreateMap<EstablishmentService, EstablishmentServiceEntity>();

    cfg.CreateMap<OrderEntity, Order>()
        .ForMember(dest => dest.EstablishmentProductId, opt => opt.MapFrom(src => src.fkEstablishmentProduct))
        .ForMember(dest => dest.EstablishmentServiceId, opt => opt.MapFrom(src => src.fkEstablishmentService));

    cfg.CreateMap<Order, OrderEntity>()
        .ForMember(dest => dest.fkEstablishmentProduct, opt => opt.MapFrom(src => src.EstablishmentProductId))
        .ForMember(dest => dest.fkEstablishmentService, opt => opt.MapFrom(src => src.EstablishmentServiceId));
});

builder.Services.AddSingleton(mapperConfig.CreateMapper());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
builder.Services.AddTransient<ICompanyService, PointOfSaleSystem.API.Services.CompanyService>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IEstablishmentRepository, EstablishmentRepository>();
builder.Services.AddTransient<IEstablishmentService, PointOfSaleSystem.API.Services.EstablishmentService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCors("AllowReactApp");

app.MapControllers();

app.Run();
