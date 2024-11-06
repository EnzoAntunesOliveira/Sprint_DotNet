using System;
using System.ComponentModel.DataAnnotations;

namespace fraude_odontologica.Application.DTOs
{
    public class ConsultaRequestDTO
    {
        [Required(ErrorMessage = "A data da consulta é obrigatória.")]
        public DateTime DataConsulta { get; set; }

        [Required(ErrorMessage = "O custo da consulta é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "O custo da consulta deve ser um valor positivo.")]
        public decimal CustoConsulta { get; set; }

        [Required(ErrorMessage = "O tipo de tratamento é obrigatório.")]
        public string TipoTratamento { get; set; }

        [Required(ErrorMessage = "O ID do paciente é obrigatório.")]
        public int PacienteId { get; set; }

        [Required(ErrorMessage = "O ID do dentista é obrigatório.")]
        public int DentistaId { get; set; }
    }
}