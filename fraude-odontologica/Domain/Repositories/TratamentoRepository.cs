using FraudeOdontologica.Domain.Entities;
using FraudeOdontologica.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace FraudeOdontologica.Presentation.Controllers.Domain.Repositories;

public class TratamentoRepository : IRepository<Tratamento>
{
    private readonly ApplicationDbContext _context;

    public TratamentoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tratamento>> GetAllAsync()
    {
        return await _context.Tratamentos.ToListAsync();
    }

    public async Task<Tratamento> GetByIdAsync(int id)
    {
        return await _context.Tratamentos.FindAsync(id);
    }

    public async Task AddAsync(Tratamento entity)
    {
        await _context.Tratamentos.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Tratamento entity)
    {
        _context.Tratamentos.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var tratamento = await _context.Tratamentos.FindAsync(id);
        if (tratamento != null)
        {
            _context.Tratamentos.Remove(tratamento);
            await _context.SaveChangesAsync();
        }
    }
}
