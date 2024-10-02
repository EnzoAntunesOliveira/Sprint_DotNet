
using FraudeOdontologica.Domain.Entities;
using FraudeOdontologica.Domain.Repositories;

namespace FraudeOdontologica.Application.Services
{
    public class ConsultaService
    {
        private readonly IConsultaRepository _consultaRepository;

        public ConsultaService(IConsultaRepository consultaRepository)
        {
            _consultaRepository = consultaRepository;
        }

        // public void VerificarFraude(Consulta consulta)
        // {
        //     // Lógica de detecção de fraude
        //     if (/* algoritmo de IA detecta padrão suspeito */)
        //     {
        //         consulta.SuspeitaDeFraude = true;
        //     }
        //
        //     _consultaRepository.AddConsulta(consulta);
        // }
    }
}