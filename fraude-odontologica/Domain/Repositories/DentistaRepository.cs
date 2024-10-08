using fraude_odontologica.Domain.Entities;
using fraude_odontologica.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace fraude_odontologica.Domain.Repositories;

public class DentistaRepository : IRepository<Dentista>
{
    private readonly ApplicationDbContext _context;

    public DentistaRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Dentista>> GetAllAsync()
    {
        return await _context.Dentistas.ToListAsync();
    }

    public async Task<Dentista> GetByIdAsync(int id)
    {
        return await _context.Dentistas.FindAsync(id);
    }

    public async Task AddAsync(Dentista entity)
    {
        await _context.Dentistas.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Dentista entity)
    {
        _context.Dentistas.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var dentista = await _context.Dentistas.FindAsync(id);
        if (dentista != null)
        {
            _context.Dentistas.Remove(dentista);
            await _context.SaveChangesAsync();
        }
    }
}
