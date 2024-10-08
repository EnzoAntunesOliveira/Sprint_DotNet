using fraude_odontologica.Application.DTOs;
using fraude_odontologica.Application.Services;
using fraude_odontologica.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace fraude_odontologica.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultasController : ControllerBase
    {
        private readonly ConsultaService _consultaService;

        public ConsultasController(ConsultaService consultaService)
        {
            _consultaService = consultaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetConsultas()
        {
            var consultas = await _consultaService.ListarTodosConsultasAsync();

            // Mapeando as consultas para o DTO de resposta
            var consultasResponse = consultas.Select(c => new ConsultaResponseDTO
            {
                IdConsulta = c.IdConsulta,
                DataConsulta = c.DataConsulta,
                CustoConsulta = c.CustoConsulta,
                TipoTratamento = c.TipoTratamento,
                Paciente = new PacienteResponseDTO
                {
                    IdPaciente = c.Paciente.IdPaciente,
                    Nome = c.Paciente.Nome,
                    CPF = c.Paciente.CPF,
                    DataNascimento = c.Paciente.DataNascimento,
                    PlanoSaude = c.Paciente.PlanoSaude,
                    Telefone = c.Paciente.Telefone,
                    Email = c.Paciente.Email
                },
                Dentista = new DentistaResponseDTO
                {
                    IdDentista = c.Dentista.IdDentista,
                    Nome = c.Dentista.Nome,
                    CRO = c.Dentista.CRO,
                    Especialidade = c.Dentista.Especialidade
                }
            }).ToList();

            return Ok(consultasResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetConsulta(int id)
        {
            var consulta = await _consultaService.BuscarConsultaPorIdAsync(id);
            if (consulta == null)
                return NotFound();

            var consultaResponse = new ConsultaResponseDTO
            {
                IdConsulta = consulta.IdConsulta,
                DataConsulta = consulta.DataConsulta,
                CustoConsulta = consulta.CustoConsulta,
                TipoTratamento = consulta.TipoTratamento,
                Paciente = new PacienteResponseDTO
                {
                    IdPaciente = consulta.Paciente.IdPaciente,
                    Nome = consulta.Paciente.Nome,
                    CPF = consulta.Paciente.CPF,
                    DataNascimento = consulta.Paciente.DataNascimento,
                    PlanoSaude = consulta.Paciente.PlanoSaude,
                    Telefone = consulta.Paciente.Telefone,
                    Email = consulta.Paciente.Email
                },
                Dentista = new DentistaResponseDTO
                {
                    IdDentista = consulta.Dentista.IdDentista,
                    Nome = consulta.Dentista.Nome,
                    CRO = consulta.Dentista.CRO,
                    Especialidade = consulta.Dentista.Especialidade
                }
            };

            return Ok(consultaResponse);
        }

        [HttpPost]
        public async Task<IActionResult> PostConsulta([FromBody] Consulta consulta)
        {
            await _consultaService.AdicionarConsultaAsync(consulta);
            return CreatedAtAction(nameof(GetConsulta), new { id = consulta.IdConsulta }, consulta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsulta(int id, [FromBody] Consulta consulta)
        {
            if (id != consulta.IdConsulta)
                return BadRequest();

            await _consultaService.AtualizarConsultaAsync(consulta);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsulta(int id)
        {
            await _consultaService.RemoverConsultaAsync(id);
            return NoContent();
        }
    }
}
