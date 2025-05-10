using System.Net;
using System.Net.Http.Json;
using fraude_odontologica.Application.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests.System;

public class WorkflowTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public WorkflowTests(WebApplicationFactory<Program> factory)
        => _client = factory.CreateClient();

    [Fact]
    public async Task Full_Flow_CreatePaciente_CreateConsulta_PaymentIntent()
    {
        var pacienteRes = await _client.PostAsJsonAsync("/api/pacientes", new { Nome = "João", Cpf = "123" });
        pacienteRes.EnsureSuccessStatusCode();
        var paciente = await pacienteRes.Content.ReadFromJsonAsync<PacienteResponseDto>();

        if (paciente != null)
        {
            var consultaRes = await _client.PostAsJsonAsync("/api/consultas", new {
                PacienteId = paciente.IdPaciente,
                Data = DateTime.UtcNow,
                Valor = 200.00m
            });
            consultaRes.EnsureSuccessStatusCode();
            var consulta = await consultaRes.Content.ReadFromJsonAsync<ConsultaResponseDto>();

            if (consulta != null)
            {
                var paymentRes = await _client.PostAsJsonAsync("/api/payments", new {
                    ConsultaId = consulta.IdConsulta,
                    Amount = consulta.CustoConsulta
                });
                Assert.Equal(HttpStatusCode.OK, paymentRes.StatusCode);
            }
        }
    }
}