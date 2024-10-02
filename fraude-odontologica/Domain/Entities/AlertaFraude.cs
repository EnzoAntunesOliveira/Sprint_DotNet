namespace FraudeOdontologica.Domain.Entities

{
    public class AlertaFraude
    {
        public int Id { get; set; }
        public int ConsultaId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAlerta { get; set; }
        
        public Consulta Consulta { get; set; }
    }
}