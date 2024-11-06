namespace fraude_odontologica.Domain.Entities
{
    public class Consulta
    {
        public int IdConsulta { get; set; }
        public DateTime DataConsulta { get; set; }
        public decimal CustoConsulta { get; set; }
        public string TipoTratamento { get; set; }
        
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; } 

   
        public int DentistaId { get; set; }
        public Dentista Dentista { get; set; } 
    }
}