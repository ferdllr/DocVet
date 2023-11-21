namespace VetAPI.Models;

public class Funcionario
{

    public int FuncionarioId { get; set; }
    public string? Nome { get; set; }
    public string? Cpf { get; set; }
    public Contato? Contato { get; set; }
    public string? TipoFuncionario { get; set; }
}