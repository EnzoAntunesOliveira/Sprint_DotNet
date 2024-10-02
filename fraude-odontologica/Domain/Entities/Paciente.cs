namespace FraudeOdontologica.Domain.Entities

{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public List<Consulta> Consultas { get; set; }
    }
}