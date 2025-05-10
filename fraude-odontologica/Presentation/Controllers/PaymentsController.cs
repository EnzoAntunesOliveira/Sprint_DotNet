using fraude_odontologica.Domain.Ports;
using Microsoft.AspNetCore.Mvc;

namespace fraude_odontologica.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly IExternalPaymentService _payment;
    public PaymentsController(IExternalPaymentService payment) => _payment = payment;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PaymentRequest req)
    {
        var intent = await _payment.CreatePaymentIntentAsync(req);
        return Ok(intent);
    }
}