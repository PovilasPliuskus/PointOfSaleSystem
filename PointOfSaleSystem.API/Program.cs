using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PointOfSaleSystem.API.Context;
using PointOfSaleSystem.API.Models.Entities;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Repositories.Interfaces;
using PointOfSaleSystem.API.Repositories;
using PointOfSaleSystem.API.Services.Interfaces;
using PointOfSaleSystem.API.Services;
using PointOfSaleSystem.API.ResponseBodies.FullOrder;
using PointOfSaleSystem.API.ResponseBodies.Order;
using PointOfSaleSystem.API.RequestBodies.Order;
using PointOfSaleSystem.API.RequestBodies.Establishment;
using PointOfSaleSystem.API.RequestBodies.EstablishmentProduct;
using PointOfSaleSystem.API.RequestBodies.EstablishmentService;
using PointOfSaleSystem.API.RequestBodies.CompanyProduct;
using PointOfSaleSystem.API.RequestBodies.CompanyService;
using PointOfSaleSystem.API.RequestBodies.Employees;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


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

    cfg.CreateMap<EstablishmentServiceEntity, PointOfSaleSystem.API.Models.EstablishmentService>();
    cfg.CreateMap<PointOfSaleSystem.API.Models.EstablishmentService, EstablishmentServiceEntity>();

    cfg.CreateMap<OrderEntity, Order>()
        .ForMember(dest => dest.EstablishmentProductId, opt => opt.MapFrom(src => src.fkEstablishmentProduct))
        .ForMember(dest => dest.EstablishmentServiceId, opt => opt.MapFrom(src => src.fkEstablishmentService));

    cfg.CreateMap<Order, OrderEntity>()
        .ForMember(dest => dest.fkEstablishmentProduct, opt => opt.MapFrom(src => src.EstablishmentProductId))
        .ForMember(dest => dest.fkEstablishmentService, opt => opt.MapFrom(src => src.EstablishmentServiceId));

    cfg.CreateMap<FullOrderEntity, FullOrder>();
    cfg.CreateMap<FullOrder, FullOrderEntity>();

    cfg.CreateMap<GetFullOrderResponse, FullOrder>();
    cfg.CreateMap<FullOrder, GetFullOrderResponse>();

    cfg.CreateMap<GetOrderResponse, Order>();
    cfg.CreateMap<Order, GetOrderResponse>();

    cfg.CreateMap<AddOrderRequest, OrderEntity>();
    cfg.CreateMap<OrderEntity, AddOrderRequest>();

    cfg.CreateMap<AddEstablishmentRequest, EstablishmentEntity>();
    cfg.CreateMap<EstablishmentEntity, AddEstablishmentRequest>();

    cfg.CreateMap<AddEstablishmentProductRequest, EstablishmentProductEntity>();
    cfg.CreateMap<EstablishmentProductEntity, AddEstablishmentProductRequest>();

    cfg.CreateMap<AddEstablishmentServiceRequest, EstablishmentServiceEntity>();
    cfg.CreateMap<EstablishmentServiceEntity, AddEstablishmentServiceRequest>();

    cfg.CreateMap<AddCompanyProductRequest, CompanyProductEntity>();
    cfg.CreateMap<CompanyProductEntity, AddCompanyProductRequest>();

    cfg.CreateMap<AddCompanyServiceRequest, CompanyServiceEntity>();
    cfg.CreateMap<CompanyServiceEntity, AddCompanyServiceRequest>();

    cfg.CreateMap<AddEmployeeRequest, EmployeeEntity>();
    cfg.CreateMap<EmployeeEntity, AddEmployeeRequest>();
});

builder.Services.AddSingleton(mapperConfig.CreateMapper());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
builder.Services.AddTransient<ICompanyService, PointOfSaleSystem.API.Services.CompanyService>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IFullOrderRepository, FullOrderRepository>();
builder.Services.AddTransient<IFullOrderService, FullOrderService>();
builder.Services.AddTransient<IEstablishmentProductRepository, EstablishmentProductRepository>();
builder.Services.AddTransient<IEstablishmentServiceRepository, EstablishmentServiceRepository>();
builder.Services.AddTransient<IEstablishmentRepository, EstablishmentRepository>();
builder.Services.AddTransient<IEstablishmentService, PointOfSaleSystem.API.Services.EstablishmentService>();
builder.Services.AddTransient<IEstablishmentProductService, EstablishmentProductService>();
builder.Services.AddTransient<IEstablishmentServiceService, EstablishmentServiceService>();
builder.Services.AddTransient<ICompanyProductRepository, CompanyProductRepository>();
builder.Services.AddTransient<ICompanyProductService, CompanyProductService>();
builder.Services.AddTransient<ICompanyServiceRepository, CompanyServiceRepository>();
builder.Services.AddTransient<ICompanyServiceService, CompanyServiceService>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IJWTService, JWTService>();
builder.Services.AddTransient<IUserInfoService, UserInfoService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var secretKey = builder.Configuration["JWTSettings:SecretKey"];
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            IssuerSigningKey = securityKey
        };
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowReactApp");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
