
using FraudeOdontologica.Domain.Entities;

namespace FraudeOdontologica.Domain.Repositories
{
    public interface IConsultaRepository
    {
        Consulta GetConsultaById(int id);
        void AddConsulta(Consulta consulta);
        List<Consulta> GetConsultasSuspeitas();
    }
}