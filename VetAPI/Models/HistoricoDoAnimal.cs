namespace VetAPI.Models;

public class HistoricoDoAnimal
{
    public int HistoricoDoAnimalId { get; set; }
    public List<Prontuario>? Prontuarios { get; set;}
}