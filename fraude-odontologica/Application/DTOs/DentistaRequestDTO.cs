using System.ComponentModel.DataAnnotations;

namespace fraude_odontologica.Application.DTOs
{
    public class DentistaRequestDTO
    {
        [Required(ErrorMessage = "O nome do dentista é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CRO é obrigatório.")]
        public string CRO { get; set; }

        [Required(ErrorMessage = "A especialidade é obrigatória.")]
        public string Especialidade { get; set; }
    }
}