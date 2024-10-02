
using FraudeOdontologica.Domain.Entities;
using FraudeOdontologica.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FraudeOdontologica.Infrastructure.Data
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly DbContext _context;

        public ConsultaRepository(DbContext context)
        {
            _context = context;
        }

        public Consulta GetConsultaById(int id)
        {
            return _context.Consultas.Find(id);
        }

        public void AddConsulta(Consulta consulta)
        {
            _context.Consultas.Add(consulta);
            _context.SaveChanges();
        }

        public List<Consulta> GetConsultasSuspeitas()
        {
            return _context.Consultas.Where(c => c.SuspeitaDeFraude).ToList();
        }
    }
}