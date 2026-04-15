using ApiAzureTarea2;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Falta ConnectionStrings:DefaultConnection en configuración.");

var serverVersion = ServerVersion.Parse("8.0.36-mysql");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, serverVersion));

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.Title = "ApiAzureTarea2 — Documentación";
    });
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
