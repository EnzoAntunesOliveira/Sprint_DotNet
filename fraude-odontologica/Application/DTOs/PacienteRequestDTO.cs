using System;
using System.ComponentModel.DataAnnotations;

namespace fraude_odontologica.Application.DTOs
{
    public class PacienteRequestDto
    {
        [Required(ErrorMessage = "O nome do paciente é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateTime DataNascimento { get; set; }

        public string PlanoSaude { get; set; }

        [Phone(ErrorMessage = "Número de telefone inválido.")]
        public string Telefone { get; set; }

        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }
    }
}