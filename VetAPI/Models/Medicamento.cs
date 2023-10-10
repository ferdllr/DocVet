using System.ComponentModel.DataAnnotations;
namespace VetAPI.Models;

public class Medicamento
{
    public enum TipoMed
    {
        Fitoterápico,
        Alopático,
        Homeopático,
        Genérico,
        Similar,
        Referência
    }

    public enum Tarja
    {
        SemTarja,
        TarjaVermelha,
        TarjaPreta,
        TarjaAmarela
    }
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public TipoMed TipoMedicamento { get; set; }
    public float Miligrama { get; set; }
    public Tarja TarjaMedicamento { get; set; }
    public DateTime Ciclo { get; set; }

}