using fraude_odontologica.Domain.Entities;
using fraude_odontologica.Domain.Repositories;

namespace fraude_odontologica.Application.Services;

public class ConsultaService
{
    private readonly IRepository<Consulta> _consultaRepository;

    public ConsultaService(IRepository<Consulta> consultaRepository)
    {
        _consultaRepository = consultaRepository;
    }

    public async Task<IEnumerable<Consulta>> ListarTodosConsultasAsync() => 
        await _consultaRepository.GetAllAsync();

    public async Task<Consulta> BuscarConsultaPorIdAsync(int id) => 
        await _consultaRepository.GetByIdAsync(id);

    public async Task AdicionarConsultaAsync(Consulta consulta) => 
        await _consultaRepository.AddAsync(consulta);

    public async Task AtualizarConsultaAsync(Consulta consulta) => 
        await _consultaRepository.UpdateAsync(consulta);

    public async Task RemoverConsultaAsync(int id) => 
        await _consultaRepository.DeleteAsync(id);
}
