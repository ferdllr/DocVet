using System.ComponentModel.DataAnnotations;

namespace VetAPI.Models;

public class Prontuario
{
    [Key]
    public int Id { get; set; }
    public Animal Animal { get; set; }
    public DateTime Data { get; set; }
    public List<EstadoAnimal> EstadosAnimais { get; set; }
    public List<Medicamento> Medicamentos { get; set; }

}