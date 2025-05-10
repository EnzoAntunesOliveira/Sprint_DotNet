using System;
using System.Threading.Tasks;
using Moq;
using Xunit;
using AutoMapper;
using fraude_odontologica.Domain.Entities;
using fraude_odontologica.Domain.Repositories;
using fraude_odontologica.Application.Services;
using fraude_odontologica.Application.DTOs;

namespace Tests
{
    public class ConsultaServiceTests
    {
        [Theory]
        [InlineData("2023-10-10", 1, 2, 150.75, "Tratamento A")]
        [InlineData("2023-11-11", 3, 4, 200.00, "Tratamento B")]
        public async Task AdicionarConsultaAsync_ChamaRepositoryAddUmaVez(
            string dataConsultaStr,
            int pacienteId,
            int dentistaId,
            double custoConsulta,
            string tipoTratamento)
        {
            // Arrange
            var dataConsulta = DateTime.Parse(dataConsultaStr);
            
            var mockRepo = new Mock<IRepository<Consulta>>();
            
            var mockMapper = new Mock<IMapper>();
            mockMapper
                .Setup(m => m.Map<Consulta>(It.IsAny<ConsultaRequestDto>()))
                .Returns<ConsultaRequestDto>(dto => new Consulta {
                    DataConsulta   = dto.DataConsulta,
                    PacienteId     = dto.PacienteId,
                    DentistaId     = dto.DentistaId,
                    CustoConsulta  = dto.CustoConsulta,
                    TipoTratamento = dto.TipoTratamento
                });
            
            var service = new ConsultaService(mockRepo.Object, mockMapper.Object);
            
            var dto = new ConsultaRequestDto {
                DataConsulta   = dataConsulta,
                PacienteId     = pacienteId,
                DentistaId     = dentistaId,
                CustoConsulta  = (decimal)custoConsulta,
                TipoTratamento = tipoTratamento
            };

            // Act
            await service.AdicionarConsultaAsync(dto);

            // Assert: 
            mockRepo.Verify(r => r.AddAsync(
                It.Is<Consulta>(c =>
                    c.DataConsulta   == dataConsulta &&
                    c.PacienteId     == pacienteId &&
                    c.DentistaId     == dentistaId &&
                    c.CustoConsulta  == (decimal)custoConsulta &&
                    c.TipoTratamento == tipoTratamento
                )
            ), Times.Once);
        }
    }
}
