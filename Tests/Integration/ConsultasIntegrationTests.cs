using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Tests.Integration;

public class ConsultasIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ConsultasIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _client = factory
            .WithWebHostBuilder(builder => {
                builder.ConfigureServices(services => {
                    var descriptor = services
                        .Single(d => d.ServiceType == typeof(DbContextOptions<DbContext>));
                    services.Remove(descriptor);
                    services.AddDbContext<DbContext>(opt =>
                        opt.UseInMemoryDatabase("TestDb"));
                });
            })
            .CreateClient();
    }

    [Fact]
    public async Task GetConsultas_ReturnsOkAndJson()
    {
        var res = await _client.GetAsync("/api/consultas");
        Assert.Equal(HttpStatusCode.OK, res.StatusCode);
        Assert.Equal("application/json", res.Content.Headers.ContentType?.MediaType);
    }
}