using System.ComponentModel.DataAnnotations;

namespace VetAPI.Models;

public class EstadoAnimal
{
    [Key]
    public int Id { get; set; }
    public string? GravidadeDoAnimal { get; set; }
    public DateTime Horario { get; set; }
    public string? Descricao { get; set; }
}