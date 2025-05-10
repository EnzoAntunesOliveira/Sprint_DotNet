using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Tests
{
    public class IntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public IntegrationTests(WebApplicationFactory<Program> factory)
        {
            
            _client = factory.CreateClient();
        }

        
        [Theory]
        [InlineData("/pacientes")]
        [InlineData("/dentistas")]
        [InlineData("/consultas")]
        public async Task GetEndpoints_DeveRetornarStatusSuccess(string url)
        {
            
            var response = await _client.GetAsync(url);
            
            
            response.EnsureSuccessStatusCode();
        }
    }
}