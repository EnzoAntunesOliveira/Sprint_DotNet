using System.Threading.Tasks;
using Moq;
using Xunit;
using fraude_odontologica.Domain.Entities;
using fraude_odontologica.Domain.Repositories;
using fraude_odontologica.Application.Services;

namespace TesteProjeto
{
    public class DentistaServiceTests
    {
        [Theory]
        [InlineData("Dr. Carlos", "CRO12345", "Ortodontia")]
        [InlineData("Dra. Fernanda", "CRO67890", "Implantodontia")]
        public async Task AdicionarDentistaAsync_ChamaRepositoryAddUmaVez(string nome, string cro, string especialidade)
        {
            
            var mockRepo = new Mock<IRepository<Dentista>>();
            var service = new DentistaService(mockRepo.Object);
            var dentista = new Dentista
            {
                Nome = nome,
                CRO = cro,
                Especialidade = especialidade
            };

      
            await service.AdicionarDentistaAsync(dentista);
            
            mockRepo.Verify(r => r.AddAsync(dentista), Times.Once);
        }
    }
}