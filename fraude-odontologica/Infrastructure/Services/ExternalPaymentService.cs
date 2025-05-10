using System.Text.Json;
using fraude_odontologica.Domain.Ports;

namespace fraude_odontologica.Infrastructure.Services
{
    public class ExternalPaymentService : IExternalPaymentService
    {
        private readonly HttpClient _http;
        public ExternalPaymentService(HttpClient http) => _http = http;

        public async Task<PaymentResult> CreatePaymentIntentAsync(PaymentRequest req)
        {
            var form = new Dictionary<string, string>
            {
                ["amount"]               = ((int)(req.Amount * 100)).ToString(), 
                ["currency"]             = "brl",
                ["payment_method_types[]"] = "card",
                ["description"]          = $"Consulta Odonto #{req.ConsultaId}"
            };
            using var content = new FormUrlEncodedContent(form);
            
            var response = await _http.PostAsync("/v1/payment_intents", content);
            response.EnsureSuccessStatusCode();
            
            using var stream = await response.Content.ReadAsStreamAsync();
            var json = await JsonDocument.ParseAsync(stream);
            var data = json.RootElement;
            
            return new PaymentResult(
                Id:           data.GetProperty("id").GetString()!,
                Status:       data.GetProperty("status").GetString()!,
                Amount:       data.GetProperty("amount_received").GetDecimal() / 100m,
                ClientSecret: data.GetProperty("client_secret").GetString()!
            );
        }
    }
}