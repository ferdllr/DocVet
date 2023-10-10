using System.ComponentModel.DataAnnotations;

namespace VetAPI.Models;

public class HistoricoDoAnimal
{
    [Key]
    public int Id { get; set; }
    public Tutor? Tutor { get; set; }
    public Animal? Animal { get; set; }
    public List<Prontuario>? Prontuarios { get; set;}
}