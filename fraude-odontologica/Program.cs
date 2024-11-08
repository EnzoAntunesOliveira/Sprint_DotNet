using fraude_odontologica.Application.Services;
using fraude_odontologica.Domain.Entities;
using fraude_odontologica.Domain.Repositories;
using fraude_odontologica.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("FiapOracleConnection")));

builder.Services.AddScoped<IRepository<Paciente>, PacienteRepository>();
builder.Services.AddScoped<IRepository<Dentista>, DentistaRepository>();
builder.Services.AddScoped<IRepository<Consulta>, ConsultaRepository>();
builder.Services.AddScoped<DentistaService>();
builder.Services.AddScoped<ConsultaService>();
builder.Services.AddScoped<PacienteService>();

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Fraude Odontológica API",
        Version = "v1"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fraude Odontológica API v1");
        c.RoutePrefix = string.Empty; 
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "consultas",
    pattern: "consultas/{action=Index}/{id?}",
    defaults: new { controller = "Consultas" });

app.MapControllerRoute(
    name: "dentistas",
    pattern: "dentistas/{action=Index}/{id?}",
    defaults: new { controller = "Dentista" });

app.MapControllerRoute(
    name: "pacientes",
    pattern: "pacientes/{action=Index}/{id?}",
    defaults: new { controller = "Paciente" });

app.MapControllers();
app.Run();
