namespace VetAPI.Models;

public class Prontuario
{
    public int ProntuarioId { get; set; }
    public Animal? Animal { get; set; }
    public DateTime Data { get; set; }
    public List<EstadoDoAnimal>? EstadosAnimais { get; set; }
    public List<Medicamento>? Medicamentos { get; set; }

}