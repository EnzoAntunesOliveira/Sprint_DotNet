namespace fraude_odontologica.Domain.Ports
{
    public record PaymentRequest(string ConsultaId, decimal Amount); 
    public record PaymentResult(string Id, string Status, decimal Amount, string ClientSecret);
    
    public interface IExternalPaymentService
    {
        Task<PaymentResult> CreatePaymentIntentAsync(PaymentRequest request);
    }
}