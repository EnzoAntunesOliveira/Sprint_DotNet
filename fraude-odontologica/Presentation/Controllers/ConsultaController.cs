using fraude_odontologica.Application.DTOs;
using fraude_odontologica.Application.Services;
using fraude_odontologica.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace fraude_odontologica.Presentation.Controllers
{
    [Route("consultas")]
    public class ConsultasController : Controller
    {
        private readonly ConsultaService _consultaService;
        private readonly PacienteService _pacienteService;
        private readonly DentistaService _dentistaService;

        public ConsultasController(ConsultaService consultaService, PacienteService pacienteService, DentistaService dentistaService)
        {
            _consultaService = consultaService ?? throw new ArgumentNullException(nameof(consultaService));
            _pacienteService = pacienteService ?? throw new ArgumentNullException(nameof(pacienteService));
            _dentistaService = dentistaService ?? throw new ArgumentNullException(nameof(dentistaService));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var consultas = await _consultaService.ListarTodosConsultasAsync();

            var consultasResponse = consultas.Select(c => new ConsultaResponseDTO
            {
                IdConsulta = c.IdConsulta,
                DataConsulta = c.DataConsulta,
                CustoConsulta = c.CustoConsulta,
                TipoTratamento = c.TipoTratamento,
                Paciente = c.Paciente == null ? null : new PacienteResponseDTO
                {
                    IdPaciente = c.Paciente.IdPaciente,
                    Nome = c.Paciente.Nome,
                    CPF = c.Paciente.CPF,
                    DataNascimento = c.Paciente.DataNascimento,
                    PlanoSaude = c.Paciente.PlanoSaude,
                    Telefone = c.Paciente.Telefone,
                    Email = c.Paciente.Email
                },
                Dentista = c.Dentista == null ? null : new DentistaResponseDTO
                {
                    IdDentista = c.Dentista.IdDentista,
                    Nome = c.Dentista.Nome,
                    CRO = c.Dentista.CRO,
                    Especialidade = c.Dentista.Especialidade
                }
            }).ToList();

            return View(consultasResponse);
        }

        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            var viewModel = new ConsultaViewModel
            {
                Pacientes = await ObterPacientesSelectList(),
                Dentistas = await ObterDentistasSelectList()
            };

            return View(viewModel);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(ConsultaViewModel consultaViewModel)
        {
            if (!ModelState.IsValid)
            {
                consultaViewModel.Pacientes = await ObterPacientesSelectList();
                consultaViewModel.Dentistas = await ObterDentistasSelectList();
                return View(consultaViewModel);
            }

            var consulta = new Consulta
            {
                DataConsulta = consultaViewModel.DataConsulta,
                PacienteId = consultaViewModel.PacienteId,
                DentistaId = consultaViewModel.DentistaId
            };

            await _consultaService.AdicionarConsultaAsync(consulta);
            return RedirectToAction("Index");
        }

        private async Task<IEnumerable<SelectListItem>> ObterPacientesSelectList()
        {
            var pacientes = await _pacienteService.ListarTodosPacientesAsync();
            return pacientes.Select(p => new SelectListItem { Value = p.IdPaciente.ToString(), Text = p.Nome });
        }

        private async Task<IEnumerable<SelectListItem>> ObterDentistasSelectList()
        {
            var dentistas = await _dentistaService.ListarTodosDentistasAsync();
            return dentistas.Select(d => new SelectListItem { Value = d.IdDentista.ToString(), Text = d.Nome });
        }
    }
}
