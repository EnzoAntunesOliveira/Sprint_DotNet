namespace FraudeOdontologica.Domain.Entities

{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public ICollection<Consulta> Consultas { get; set; }
    }
}