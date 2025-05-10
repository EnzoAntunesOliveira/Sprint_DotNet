using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace fraude_odontologica.ViewModels;

public class ConsultaViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Paciente é obrigatório")]
    public int PacienteId { get; set; }

    [Required(ErrorMessage = "Dentista é obrigatório")]
    public int DentistaId { get; set; }

    [Required(ErrorMessage = "Data da Consulta é obrigatória")]
    [DataType(DataType.Date)]
    public DateTime DataConsulta { get; set; }

    public IEnumerable<SelectListItem> Pacientes { get; set; }
    public IEnumerable<SelectListItem> Dentistas { get; set; }
}