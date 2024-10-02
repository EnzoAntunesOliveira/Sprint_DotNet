namespace FraudeOdontologica.Domain.Entities

{
    public class Consulta
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public Paciente Paciente { get; set; }
        public Dentista Dentista { get; set; }
        public bool SuspeitaDeFraude { get; set; }
    }
}