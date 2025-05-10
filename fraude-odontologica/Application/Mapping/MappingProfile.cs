using AutoMapper;
using fraude_odontologica.Application.DTOs;
using fraude_odontologica.ViewModels;
using fraude_odontologica.Domain.Entities;

namespace fraude_odontologica.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ConsultaViewModel, ConsultaRequestDto>()
                .ForMember(d => d.PacienteId,   o => o.MapFrom(s => s.PacienteId))
                .ForMember(d => d.DentistaId,   o => o.MapFrom(s => s.DentistaId))
                .ForMember(d => d.DataConsulta, o => o.MapFrom(s => s.DataConsulta))
                ;
            
            CreateMap<ConsultaRequestDto, Consulta>()
                .ForMember(d => d.PacienteId,   o => o.MapFrom(s => s.PacienteId))
                .ForMember(d => d.DentistaId,   o => o.MapFrom(s => s.DentistaId))
                .ForMember(d => d.DataConsulta, o => o.MapFrom(s => s.DataConsulta))
                ;
            
            CreateMap<Consulta, ConsultaResponseDto>()
                .ForMember(d => d.Paciente,   o => o.MapFrom(s => s.Paciente))
                .ForMember(d => d.Dentista,   o => o.MapFrom(s => s.Dentista));
        }
    }
}