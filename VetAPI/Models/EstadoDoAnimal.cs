namespace VetAPI.Models;

public class EstadoDoAnimal
{
    public enum Gravidade
    {
        Azul,
        Verde,
        Amarelo,
        Laranja,
        Vermelho
    }
    public int EstadoDoAnimalId { get; set; }
    public Gravidade GravidadeDoAnimal { get; set; }
    public DateTime Horario { get; set; }
    public string? Descricao { get; set; }
}