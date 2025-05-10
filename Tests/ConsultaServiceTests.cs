using System;
using System.Threading.Tasks;
using Moq;
using Xunit;
using fraude_odontologica.Domain.Entities;
using fraude_odontologica.Domain.Repositories;
using fraude_odontologica.Application.Services;

namespace Tests
{
    public class ConsultaServiceTests
    {
        [Theory]
        [InlineData("2023-10-10", 1, 2, 150.75, "Tratamento A")]
        [InlineData("2023-11-11", 3, 4, 200.00, "Tratamento B")]
        public async Task AdicionarConsultaAsync_ChamaRepositoryAddUmaVez(string dataConsultaStr, int pacienteId, int dentistaId, double custoConsulta, string tipoTratamento)
        {
            
            var mockRepo = new Mock<IRepository<Consulta>>();
            var service = new ConsultaService(mockRepo.Object);
            DateTime dataConsulta = DateTime.Parse(dataConsultaStr);

            var consulta = new Consulta
            {
                DataConsulta = dataConsulta,
                PacienteId = pacienteId,
                DentistaId = dentistaId,
                CustoConsulta = (decimal)custoConsulta,
                TipoTratamento = tipoTratamento
            };

            
            await service.AdicionarConsultaAsync(consulta);

         
            mockRepo.Verify(r => r.AddAsync(consulta), Times.Once);
        }
    }
}