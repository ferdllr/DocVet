namespace VetAPI.Models;

public class Medicamento
{
    public int MedicamentoId { get; set; }
    public string? Nome { get; set; }
    public string? TipoMedicamento { get; set; }
    public float Miligrama { get; set; }
    public string? TarjaMedicamento { get; set; }
    public string? Ciclo { get; set; }

}