using Microsoft.AspNetCore.Mvc;
using FraudeOdontologica.Application.Services;
using FraudeOdontologica.Application.DTOs;

namespace FraudeOdontologica.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultaController : ControllerBase
    {
        private readonly ConsultaService _consultaService;

        public ConsultaController(ConsultaService consultaService)
        {
            _consultaService = consultaService;
        }

        [HttpPost("verificar")]
        public IActionResult VerificarConsulta([FromBody] ConsultaDTO consultaDTO)
        {
            var resultado = _consultaService.VerificarFraude(consultaDTO);

            if (resultado.SuspeitaDeFraude)
            {
                return Ok("Fraude detectada.");
            }
            return Ok("Nenhuma fraude detectada.");
        }
    }
}