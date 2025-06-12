using EasyHost.Application.Interfaces;
using EasyHost.Application.Services;
using EasyHost.Domain.Entities;
using EasyHost.Domain.Interfaces;
using EasyHost.Infrastructure.Data;
using EasyHost.Infrastructure.Repositorys;
using Microsoft.AspNetCore.Identity;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(doc =>
{
    doc.SwaggerDoc("v1", new()
    {
        Title = "EasyHost API",
        Version = "v1",
        Description = "Api do sistema EasyHost - gerenciamento de hoteis.",
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    doc.IncludeXmlComments(xmlPath);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("PoliticaCors", policy =>
    {
        policy.WithOrigins("http://localhost:3000", "https://localhost:3000").AllowAnyHeader().AllowAnyMethod();
    });
});

//quando incluir interfaces e classe insira a linha abaixo, injen��o de dependencia o .net entende e passa os parametros nescessario para as classe
builder.Services.AddScoped<IDataConnection, DataConnection>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IPasswordHasher<Usuario>, PasswordHasher<Usuario>>();
builder.Services.AddScoped<IJwtService, JwtService>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapSwagger();

app.UseCors("PoliticaCors");

app.UseAuthorization();

app.MapControllers();

app.Run();