namespace fraude_odontologica.Application.DTOs;

public class ConsultaResponseDto
{
    public int IdConsulta { get; set; }
    public DateTime DataConsulta { get; set; }
    public decimal CustoConsulta { get; set; }
    public string TipoTratamento { get; set; }

    public PacienteResponseDto Paciente { get; set; }
    public DentistaResponseDto Dentista { get; set; }
}