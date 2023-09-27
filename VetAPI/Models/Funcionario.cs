namespace VetAPI.Models;

public class Funcionario
{
    public enum Tipo
    {
        Ortopedista,
        Neurologista,
        Cardiologista,
        Enfermeiro,
        Estagiário
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public Contato Contato { get; set; }
    public Tipo TipoFuncionario { get; set; }

}