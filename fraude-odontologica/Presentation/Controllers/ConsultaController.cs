using fraude_odontologica.Application.DTOs;
using fraude_odontologica.Application.Services;
using fraude_odontologica.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

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
                return NotFound(new { message = "Consulta não encontrada." });

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
        public async Task<IActionResult> PostConsulta([FromBody] ConsultaRequestDTO consultaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var consulta = new Consulta
            {
                DataConsulta = consultaDto.DataConsulta,
                CustoConsulta = consultaDto.CustoConsulta,
                TipoTratamento = consultaDto.TipoTratamento,
                PacienteId = consultaDto.PacienteId,
                DentistaId = consultaDto.DentistaId
            };

            await _consultaService.AdicionarConsultaAsync(consulta);
            return CreatedAtAction(nameof(GetConsulta), new { id = consulta.IdConsulta }, consulta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsulta(int id, [FromBody] ConsultaRequestDTO consultaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var consultaExistente = await _consultaService.BuscarConsultaPorIdAsync(id);
            if (consultaExistente == null)
                return NotFound(new { message = "Consulta não encontrada para atualização." });

            consultaExistente.DataConsulta = consultaDto.DataConsulta;
            consultaExistente.CustoConsulta = consultaDto.CustoConsulta;
            consultaExistente.TipoTratamento = consultaDto.TipoTratamento;
            consultaExistente.PacienteId = consultaDto.PacienteId;
            consultaExistente.DentistaId = consultaDto.DentistaId;

            await _consultaService.AtualizarConsultaAsync(consultaExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsulta(int id)
        {
            var consultaExistente = await _consultaService.BuscarConsultaPorIdAsync(id);
            if (consultaExistente == null)
                return NotFound(new { message = "Consulta não encontrada para exclusão." });

            await _consultaService.RemoverConsultaAsync(id);
            return NoContent();
        }
    }
}
