using CRUDMARKET.DOMAIN.Context;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Configuración de servicios de la aplicación
builder.Services.AddControllers();

// Configuración de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inyección de dependencias para AppDbContext usando la cadena de conexión
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configuración del pipeline de la aplicación
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    // Activar Swagger en desarrollo
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
