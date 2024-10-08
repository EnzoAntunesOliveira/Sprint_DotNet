namespace fraude_odontologica.Application.DTOs;

public class PacienteResponseDTO
{
    public int IdPaciente { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public DateTime DataNascimento { get; set; }
    public string PlanoSaude { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
}