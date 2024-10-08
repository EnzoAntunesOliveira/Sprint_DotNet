using fraude_odontologica.Domain.Entities;
using fraude_odontologica.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace fraude_odontologica.Domain.Repositories;

public class ConsultaRepository : IRepository<Consulta>
{
    private readonly ApplicationDbContext _context;

    public ConsultaRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Consulta>> GetAllAsync()
    {
        return await _context.Consultas.ToListAsync();
    }

    public async Task<Consulta> GetByIdAsync(int id)
    {
        return await _context.Consultas.FindAsync(id);
    }

    public async Task AddAsync(Consulta entity)
    {
        await _context.Consultas.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Consulta entity)
    {
        _context.Consultas.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var consulta = await _context.Consultas.FindAsync(id);
        if (consulta != null)
        {
            _context.Consultas.Remove(consulta);
            await _context.SaveChangesAsync();
        }
    }
}
