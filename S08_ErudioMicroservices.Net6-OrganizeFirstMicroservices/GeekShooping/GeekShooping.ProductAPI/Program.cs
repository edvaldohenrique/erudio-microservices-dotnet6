using AutoMapper;
using GeekShooping.ProductAPI.Config;
using GeekShooping.ProductAPI.Model.Context;
using GeekShooping.ProductAPI.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;

//Config EntityFrameWork
var connection = configuration["MySqlConnection:MySqlConnectionString"];

builder.Services.AddControllers();
builder.Services.AddDbContext<MySqlContext>(options => options.
    UseMySql(connection, 
             new MySqlServerVersion(
                 new Version(8,0,28))));

//AutoMapper
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Injetec da interface de repositorio
builder.Services.AddScoped<IProductRepository, ProductRepository>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
