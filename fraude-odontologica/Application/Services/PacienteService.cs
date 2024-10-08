using fraude_odontologica.Domain.Entities;
using fraude_odontologica.Domain.Repositories;

namespace fraude_odontologica.Application.Services;

public class PacienteService
{
    private readonly IRepository<Paciente> _pacienteRepository;

    public PacienteService(IRepository<Paciente> pacienteRepository)
    {
        _pacienteRepository = pacienteRepository;
    }

    public async Task<IEnumerable<Paciente>> ListarTodosPacientesAsync() => await _pacienteRepository.GetAllAsync();

    public async Task<Paciente> BuscarPacientePorIdAsync(int id) => await _pacienteRepository.GetByIdAsync(id);

    public async Task AdicionarPacienteAsync(Paciente paciente) => await _pacienteRepository.AddAsync(paciente);

    public async Task AtualizarPacienteAsync(Paciente paciente) => await _pacienteRepository.UpdateAsync(paciente);

    public async Task RemoverPacienteAsync(int id) => await _pacienteRepository.DeleteAsync(id);
}
