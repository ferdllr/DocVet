namespace VetAPI.Models;

public class Funcionario
{
    public int FuncionarioId { get; set; }
    public string? Nome { get; set; }
    public string? Cpf { get; set; }
    public string? Telefone {get;set;}
    public string? Email{get;set;}
    public string? TipoFuncionario { get; set; }
}