namespace fraude_odontologica.Domain.Entities
{
    public class Consulta
    {
        public int IdConsulta { get; set; }
        public DateTime DataConsulta { get; set; }
        public decimal CustoConsulta { get; set; }
        public string TipoTratamento { get; set; }

        public Paciente Paciente { get; set; } // Referência ao objeto Paciente
        public Dentista Dentista { get; set; } // Referência ao objeto Dentista
    }
}