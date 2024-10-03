using FraudeOdontologica.Domain.Entities;
using FraudeOdontologica.Presentation.Controllers.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FraudeOdontologica.Presentation.Controllers.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PacientesController : ControllerBase
{
    private readonly PacienteService _pacienteService;

    public PacientesController(PacienteService pacienteService)
    {
        _pacienteService = pacienteService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPacientes()
    {
        var pacientes = await _pacienteService.ListarTodosPacientesAsync();
        return Ok(pacientes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPaciente(int id)
    {
        var paciente = await _pacienteService.BuscarPacientePorIdAsync(id);
        if (paciente == null)
            return NotFound();

        return Ok(paciente);
    }

    [HttpPost]
    public async Task<IActionResult> PostPaciente(Paciente paciente)
    {
        await _pacienteService.AdicionarPacienteAsync(paciente);
        return CreatedAtAction(nameof(GetPaciente), new { id = paciente.Id }, paciente);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutPaciente(int id, Paciente paciente)
    {
        if (id != paciente.Id)
            return BadRequest();

        await _pacienteService.AtualizarPacienteAsync(paciente);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePaciente(int id)
    {
        await _pacienteService.RemoverPacienteAsync(id);
        return NoContent();
    }
}
