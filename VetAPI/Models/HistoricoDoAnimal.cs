namespace VetAPI.Models;

public class HistoricoDoAnimal
{
    public int Id { get; set; }
    public Tutor Tutor { get; set; }
    public Animal Animal { get; set; }
    public List<Prontuario> prontuarios { get; set;}
}