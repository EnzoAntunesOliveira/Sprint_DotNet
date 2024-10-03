namespace FraudeOdontologica.Domain.Entities;

public class Tratamento
{
    public int Id { get; set; }
    public string NomeTratamento { get; set; }
    public decimal Custo { get; set; }
    public int ConsultaId { get; set; } 
    public Consulta Consulta { get; set; } 
}
