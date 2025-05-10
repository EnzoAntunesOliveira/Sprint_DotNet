using AutoMapper;
using fraude_odontologica.Application.DTOs;
using fraude_odontologica.Domain.Entities;
using fraude_odontologica.Domain.Repositories;

namespace fraude_odontologica.Application.Services
{
    public class ConsultaService
    {
        private readonly IRepository<Consulta> _repo;
        private readonly IMapper _mapper;

        public ConsultaService(IRepository<Consulta> repo, IMapper mapper)
        {
            _repo   = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Consulta>> ListarTodosConsultasAsync()
            => await _repo.GetAllAsync();

        public async Task<Consulta> BuscarConsultaPorIdAsync(int id)
            => await _repo.GetByIdAsync(id);
        public async Task AdicionarConsultaAsync(ConsultaRequestDto dto)
        {
            var consulta = _mapper.Map<Consulta>(dto);
            await _repo.AddAsync(consulta);
        }

        public async Task AtualizarConsultaAsync(ConsultaRequestDto dto)
        {
            var consulta = _mapper.Map<Consulta>(dto);
            await _repo.UpdateAsync(consulta);
        }

        public async Task RemoverConsultaAsync(int id)
            => await _repo.DeleteAsync(id);
    }
}