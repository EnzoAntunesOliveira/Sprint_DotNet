using fraude_odontologica.Application.Services;
using fraude_odontologica.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace fraude_odontologica.Presentation.Controllers
{
    [Route("dentistas")]
    public class DentistasController : Controller
    {
        private readonly DentistaService _dentistaService;

        public DentistasController(DentistaService dentistaService)
        {
            _dentistaService = dentistaService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dentistas = await _dentistaService.ListarTodosDentistasAsync();
            return View(dentistas);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(Dentista dentista)
        {
            if (!ModelState.IsValid)
                return View(dentista);

            await _dentistaService.AdicionarDentistaAsync(dentista);
            return RedirectToAction("Index");
        }
    }
}