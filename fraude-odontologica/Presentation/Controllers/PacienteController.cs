using fraude_odontologica.Application.DTOs;
using fraude_odontologica.Application.Services;
using fraude_odontologica.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace fraude_odontologica.Presentation.Controllers
{
    [Route("pacientes")]
    public class PacienteController : Controller
    {
        private readonly PacienteService _pacienteService;

        public PacienteController(PacienteService pacienteService)
        {
            _pacienteService = pacienteService ?? throw new ArgumentNullException(nameof(pacienteService));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var pacientes = await _pacienteService.ListarTodosPacientesAsync();
            var pacientesResponse = pacientes.Select(p => new PacienteResponseDto
            {
                IdPaciente = p.IdPaciente,
                Nome = p.Nome,
                CPF = p.CPF,
                DataNascimento = p.DataNascimento,
                PlanoSaude = p.PlanoSaude,
                Telefone = p.Telefone,
                Email = p.Email
            }).ToList();

            return View("Index", pacientesResponse); 
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View(new PacienteRequestDto());
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(PacienteRequestDto pacienteDto)
        {
            if (!ModelState.IsValid)
            {
                return View(pacienteDto);
            }

            var paciente = new Paciente
            {
                Nome = pacienteDto.Nome,
                CPF = pacienteDto.CPF,
                DataNascimento = pacienteDto.DataNascimento,
                PlanoSaude = pacienteDto.PlanoSaude,
                Telefone = pacienteDto.Telefone,
                Email = pacienteDto.Email
            };

            await _pacienteService.AdicionarPacienteAsync(paciente);
            return RedirectToAction("Index");
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var paciente = await _pacienteService.BuscarPacientePorIdAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }

            var pacienteDto = new PacienteRequestDto
            {
                Nome = paciente.Nome,
                CPF = paciente.CPF,
                DataNascimento = paciente.DataNascimento,
                PlanoSaude = paciente.PlanoSaude,
                Telefone = paciente.Telefone,
                Email = paciente.Email
            };

            return View(pacienteDto);
        }

        [HttpPost("edit/{id}")]
        public async Task<IActionResult> Edit(int id, PacienteRequestDto pacienteDto)
        {
            if (!ModelState.IsValid)
            {
                return View(pacienteDto);
            }

            var paciente = await _pacienteService.BuscarPacientePorIdAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }

            paciente.Nome = pacienteDto.Nome;
            paciente.CPF = pacienteDto.CPF;
            paciente.DataNascimento = pacienteDto.DataNascimento;
            paciente.PlanoSaude = pacienteDto.PlanoSaude;
            paciente.Telefone = pacienteDto.Telefone;
            paciente.Email = pacienteDto.Email;

            await _pacienteService.AtualizarPacienteAsync(paciente);
            return RedirectToAction("Index");
        }

        [HttpPost("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var paciente = await _pacienteService.BuscarPacientePorIdAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }

            await _pacienteService.RemoverPacienteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
