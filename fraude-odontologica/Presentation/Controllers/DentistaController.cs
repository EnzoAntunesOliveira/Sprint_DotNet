using fraude_odontologica.Application.Services;
using fraude_odontologica.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace fraude_odontologica.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DentistasController : ControllerBase
    {
        private readonly DentistaService _dentistaService;

        public DentistasController(DentistaService dentistaService)
        {
            _dentistaService = dentistaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDentistas()
        {
            var dentistas = await _dentistaService.ListarTodosDentistasAsync();
            return Ok(dentistas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDentista(int id)
        {
            var dentista = await _dentistaService.BuscarDentistaPorIdAsync(id);
            if (dentista == null)
                return NotFound();

            return Ok(dentista);
        }

        [HttpPost]
        public async Task<IActionResult> PostDentista(Dentista dentista)
        {
            await _dentistaService.AdicionarDentistaAsync(dentista);
            return CreatedAtAction(nameof(GetDentista), new { id = dentista.IdDentista }, dentista);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDentista(int id, Dentista dentista)
        {
            if (id != dentista.IdDentista)
                return BadRequest();

            await _dentistaService.AtualizarDentistaAsync(dentista);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDentista(int id)
        {
            await _dentistaService.RemoverDentistaAsync(id);
            return NoContent();
        }
    }
}