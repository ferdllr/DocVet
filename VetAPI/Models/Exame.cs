namespace VetAPI.Models;

public class Exame
{
    public enum TipoExam
    {
        Hemograma,
        Radiografia,
        Ultrassonografia,
        Urinalise
    }
    public int? ExameId { get; set;}
    public TipoExam? TipoExame { get; set;}
    public DateTime? Data { get; set;}
    public string? Observacao {get; set;}
    
    
}