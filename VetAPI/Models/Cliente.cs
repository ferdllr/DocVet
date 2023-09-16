namespace VetAPI.Models;

public class Cliente
{
    public int Id { get; set;}
    public string Nome { get; set;}
    public string Cpf { get; set;}
    public DateTime DataNascimento { get; set;}
    public Logradouro Logradouro{ get; set;}
    public Contato Contato { get; set;}
    
}