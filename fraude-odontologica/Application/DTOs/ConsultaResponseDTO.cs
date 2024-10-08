using fraude_odontologica.Application.DTOs;

public class ConsultaResponseDTO
{
    public int IdConsulta { get; set; }
    public DateTime DataConsulta { get; set; }
    public decimal CustoConsulta { get; set; }
    public string TipoTratamento { get; set; }

    public PacienteResponseDTO Paciente { get; set; }
    public DentistaResponseDTO Dentista { get; set; }
}