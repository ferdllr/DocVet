using System.ComponentModel.DataAnnotations;
namespace VetAPI.Models;

public class Exame
{
    public enum Tipo
    {
        Hemograma,
        Radiografia,
        Ultrassonografia,
        Urinalise
    }
    [Key]
    public int? Id { get; set;}
    public Tipo? TipoExame { get; set;}
    public DateTime? Data { get; set;}
    public string? Observacao {get; set;}
    
    
}