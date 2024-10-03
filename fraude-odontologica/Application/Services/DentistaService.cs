using FraudeOdontologica.Domain.Entities;
using FraudeOdontologica.Presentation.Controllers.Domain.Repositories;
namespace FraudeOdontologica.Presentation.Controllers.Application.Services;

public class DentistaService
{
    private readonly IRepository<Dentista> _dentistaRepository;

    public DentistaService(IRepository<Dentista> dentistaRepository)
    {
        _dentistaRepository = dentistaRepository;
    }

    public async Task<IEnumerable<Dentista>> ListarTodosDentistasAsync() => 
        await _dentistaRepository.GetAllAsync();

    public async Task<Dentista> BuscarDentistaPorIdAsync(int id) => 
        await _dentistaRepository.GetByIdAsync(id);

    public async Task AdicionarDentistaAsync(Dentista dentista) => 
        await _dentistaRepository.AddAsync(dentista);

    public async Task AtualizarDentistaAsync(Dentista dentista) => 
        await _dentistaRepository.UpdateAsync(dentista);

    public async Task RemoverDentistaAsync(int id) => 
        await _dentistaRepository.DeleteAsync(id);
}
