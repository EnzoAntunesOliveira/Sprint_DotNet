using System;
using System.Threading.Tasks;
using Moq;
using Xunit;
using fraude_odontologica.Domain.Entities;
using fraude_odontologica.Domain.Repositories;
using fraude_odontologica.Application.Services;

namespace Tests
{
    public class PacienteServiceTests
    {
        [Theory]
        [InlineData("João Silva", "12345678901", "2000-01-01", "Plano A", "(11) 9999-9999", "joao@example.com")]
        [InlineData("Maria Oliveira", "10987654321", "1995-05-15", "Plano B", "(21) 8888-8888", "maria@teste.com")]
        public async Task AdicionarPacienteAsync_ChamaRepositoryAddUmaVez(string nome, string cpf, string dtNascimento, string planoSaude, string telefone, string email)
        {
        
            var mockRepo = new Mock<IRepository<Paciente>>();
            var service = new PacienteService(mockRepo.Object);

            DateTime dataNascimento = DateTime.Parse(dtNascimento);

            var paciente = new Paciente
            {
                Nome = nome,
                CPF = cpf,
                DataNascimento = dataNascimento,
                PlanoSaude = planoSaude,
                Telefone = telefone,
                Email = email
            };

        
            await service.AdicionarPacienteAsync(paciente);

           
            mockRepo.Verify(r => r.AddAsync(paciente), Times.Once);
        }
    }
}