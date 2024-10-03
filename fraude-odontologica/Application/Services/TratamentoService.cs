using FraudeOdontologica.Domain.Entities;
using FraudeOdontologica.Presentation.Controllers.Domain.Repositories;

namespace FraudeOdontologica.Presentation.Controllers.Application.Services;

public class TratamentoService
{
    private readonly IRepository<Tratamento> _tratamentoRepository;

    public TratamentoService(IRepository<Tratamento> tratamentoRepository)
    {
        _tratamentoRepository = tratamentoRepository;
    }

    public async Task<IEnumerable<Tratamento>> ListarTodosTratamentosAsync() => 
        await _tratamentoRepository.GetAllAsync();

    public async Task<Tratamento> BuscarTratamentoPorIdAsync(int id) => 
        await _tratamentoRepository.GetByIdAsync(id);

    public async Task AdicionarTratamentoAsync(Tratamento tratamento) => 
        await _tratamentoRepository.AddAsync(tratamento);

    public async Task AtualizarTratamentoAsync(Tratamento tratamento) => 
        await _tratamentoRepository.UpdateAsync(tratamento);

    public async Task RemoverTratamentoAsync(int id) => 
        await _tratamentoRepository.DeleteAsync(id);
}
