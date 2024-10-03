using System.ComponentModel.DataAnnotations;

namespace FraudeOdontologica.Application.DTOs

{
    public class ConsultaDTO
    {
        [Required]
        public int PacienteId { get; set; }

        [Required]
        public int DentistaId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
    }

}