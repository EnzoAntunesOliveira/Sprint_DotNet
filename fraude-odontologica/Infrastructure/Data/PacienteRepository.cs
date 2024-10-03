﻿using FraudeOdontologica.Domain.Entities;
using FraudeOdontologica.Presentation.Controllers.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FraudeOdontologica.Infrastructure.Data;

public class PacienteRepository : IRepository<Paciente>
{
    private readonly ApplicationDbContext _context;

    public PacienteRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Paciente>> GetAllAsync() => await _context.Pacientes.ToListAsync();

    public async Task<Paciente> GetByIdAsync(int id) => await _context.Pacientes.FindAsync(id);

    public async Task AddAsync(Paciente entity)
    {
        _context.Pacientes.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Paciente entity)
    {
        _context.Pacientes.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var paciente = await _context.Pacientes.FindAsync(id);
        _context.Pacientes.Remove(paciente);
        await _context.SaveChangesAsync();
    }
}
