using fraude_odontologica.Application.DTOs;
using fraude_odontologica.Application.Services;
using fraude_odontologica.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace fraude_odontologica.Presentation.Controllers
{
    [Route("dentistas")]
    public class DentistaController : Controller
    {
        private readonly DentistaService _dentistaService;

        public DentistaController(DentistaService dentistaService)
        {
            _dentistaService = dentistaService ?? throw new ArgumentNullException(nameof(dentistaService));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dentistas = await _dentistaService.ListarTodosDentistasAsync();
            var dentistasResponse = dentistas.Select(d => new DentistaResponseDto
            {
                IdDentista = d.IdDentista,
                Nome = d.Nome,
                CRO = d.CRO,
                Especialidade = d.Especialidade
            }).ToList();

            return View(dentistasResponse);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View(new DentistaRequestDto());
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(DentistaRequestDto dentistaDto)
        {
            if (!ModelState.IsValid)
            {
                return View(dentistaDto);
            }

            var dentista = new Dentista
            {
                Nome = dentistaDto.Nome,
                CRO = dentistaDto.CRO,
                Especialidade = dentistaDto.Especialidade
            };

            await _dentistaService.AdicionarDentistaAsync(dentista);
            return RedirectToAction("Index");
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var dentista = await _dentistaService.BuscarDentistaPorIdAsync(id);

            var dentistaDto = new DentistaRequestDto
            {
                Nome = dentista.Nome,
                CRO = dentista.CRO,
                Especialidade = dentista.Especialidade
            };

            return View(dentistaDto);
        }

        [HttpPost("edit/{id}")]
        public async Task<IActionResult> Edit(int id, DentistaRequestDto dentistaDto)
        {
            if (!ModelState.IsValid)
            {
                return View(dentistaDto);
            }

            var dentista = await _dentistaService.BuscarDentistaPorIdAsync(id);

            dentista.Nome = dentistaDto.Nome;
            dentista.CRO = dentistaDto.CRO;
            dentista.Especialidade = dentistaDto.Especialidade;

            await _dentistaService.AtualizarDentistaAsync(dentista);
            return RedirectToAction("Index");
        }

        [HttpPost("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dentista = await _dentistaService.BuscarDentistaPorIdAsync(id);
            if (dentista == null)
            {
                return NotFound();
            }

            await _dentistaService.RemoverDentistaAsync(id);
            return RedirectToAction("Index");
        }
    }
}
