using fraude_odontologica.Infrastructure.Services;
using RichardSzalay.MockHttp;

namespace Tests.Unit;

public class PaymentServiceTests
{
    [Fact]
    public async Task CreatePaymentIntentAsync_ReturnsIntentInfo_OnSuccess()
    {
        // Arrange
        var mock = new MockHttpMessageHandler();
        mock.When("https://api.stripe.com/v1/payment_intents")
            .Respond("application/json", @"{
                ""id"": ""pi_123"",
                ""status"": ""requires_payment_method"",
                ""amount_received"": 15000,
                ""client_secret"": ""secret_abc""
            }");
        var client = mock.ToHttpClient();
        client.BaseAddress = new Uri("https://api.stripe.com/v1");

        var service = new ExternalPaymentService(client);

        // Act
        var result = await service.CreatePaymentIntentAsync(new("c1", 150.00m));

        // Assert
        Assert.Equal("pi_123", result.Id);
        Assert.Equal("requires_payment_method", result.Status);
        Assert.Equal(150.00m, result.Amount);
        Assert.Equal("secret_abc", result.ClientSecret);
    }
}