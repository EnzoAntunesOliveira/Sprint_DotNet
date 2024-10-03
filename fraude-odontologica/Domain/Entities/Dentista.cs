namespace FraudeOdontologica.Domain.Entities

{
    public class Dentista
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CRO { get; set; }
        public ICollection<Consulta> Consultas { get; set; }
    }
}