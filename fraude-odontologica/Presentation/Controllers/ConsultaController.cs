using AutoMapper;
using fraude_odontologica.Application.DTOs;
using fraude_odontologica.Application.Services;
using fraude_odontologica.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using fraude_odontologica.Domain.Entities;

namespace fraude_odontologica.Presentation.Controllers
{
    [Route("consultas")]
    public class ConsultasController : Controller
    {
        private readonly ConsultaService         _consultaService;
        private readonly PacienteService        _pacienteService;
        private readonly DentistaService        _dentistaService;
        private readonly IMapper                _mapper;

        public ConsultasController(
            ConsultaService consultaService,
            PacienteService pacienteService,
            DentistaService dentistaService,
            IMapper mapper)
        {
            _consultaService  = consultaService;
            _pacienteService  = pacienteService;
            _dentistaService  = dentistaService;
            _mapper           = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var consultas = await _consultaService.ListarTodosConsultasAsync();
            var vm = _mapper.Map<IEnumerable<ConsultaResponseDto>>(consultas);
            return View(vm);
        }

        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            var vm = new ConsultaViewModel
            {
                Pacientes = (await _pacienteService.ListarTodosPacientesAsync())
                                .Select(p => new SelectListItem(p.Nome, p.IdPaciente.ToString())),
                Dentistas = (await _dentistaService.ListarTodosDentistasAsync())
                                .Select(d => new SelectListItem(d.Nome, d.IdDentista.ToString()))
            };
            return View(vm);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(ConsultaViewModel m)
        {
            if (!ModelState.IsValid)
            {
                m.Pacientes = (await _pacienteService.ListarTodosPacientesAsync())
                                .Select(p => new SelectListItem(p.Nome, p.IdPaciente.ToString()));
                m.Dentistas = (await _dentistaService.ListarTodosDentistasAsync())
                                .Select(d => new SelectListItem(d.Nome, d.IdDentista.ToString()));
                return View(m);
            }
            
            ConsultaRequestDto dto = _mapper.Map<ConsultaRequestDto>(m);
            await _consultaService.AdicionarConsultaAsync(dto);

            return RedirectToAction(nameof(Index));
        }
    }
}
