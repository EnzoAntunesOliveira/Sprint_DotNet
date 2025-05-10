using fraude_odontologica.Domain.Ports;
using FraudeOdonto.ML;
using Microsoft.AspNetCore.Mvc;

namespace fraude_odontologica.Presentation.Controllers
{
    [ApiController]
    [Route("api/fraud")]
    public class FraudController : ControllerBase
    {
        private readonly IFraudDetectionService _fraudService;

        public FraudController(IFraudDetectionService fraudService)
        {
            _fraudService = fraudService;
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] ConsultaData dto)
        {
            if (dto == null)
                return BadRequest("Dados de consulta não informados.");

            var prediction = _fraudService.Predict(dto);
            return Ok(prediction);
        }
    }
}