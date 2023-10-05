using System.ComponentModel.DataAnnotations;

namespace VetAPI.Models;

public class EstadoAnimal
{
    public enum Gravidade
    {
        Azul,
        Verde,
        Amarelo,
        Laranja,
        Vermelho
    }
    [Key]
    public int id { get; set; }
    public Gravidade GravidadeDoAnimal { get; set; }
    public DateTime horario { get; set; }
    public string descricao { get; set; }
}