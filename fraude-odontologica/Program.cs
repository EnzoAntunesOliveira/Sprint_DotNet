using FraudeOdontologica.Domain.Entities;
using FraudeOdontologica.Infrastructure.Data;
using FraudeOdontologica.Presentation.Controllers.Application.Services;
using FraudeOdontologica.Presentation.Controllers.Domain.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("FiapOracleConnection")));

builder.Services.AddScoped<IRepository<Paciente>, PacienteRepository>();
builder.Services.AddScoped<IRepository<Dentista>, DentistaRepository>();
builder.Services.AddScoped<IRepository<Consulta>, ConsultaRepository>();
builder.Services.AddScoped<IRepository<Tratamento>, TratamentoRepository>();


builder.Services.AddScoped<DentistaService>();
builder.Services.AddScoped<ConsultaService>();
builder.Services.AddScoped<TratamentoService>();


builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
app.MapControllers();
app.Run();