using fraude_odontologica.Application.Services;
using fraude_odontologica.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace fraude_odontologica.Presentation.Controllers
{
    [Route("pacientes")]
    public class PacientesController : Controller
    {
        private readonly PacienteService _pacienteService;

        public PacientesController(PacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var pacientes = await _pacienteService.ListarTodosPacientesAsync();
            return View(pacientes);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(Paciente paciente)
        {
            if (!ModelState.IsValid)
                return View(paciente);

            await _pacienteService.AdicionarPacienteAsync(paciente);
            return RedirectToAction("Index");
        }
    }
}