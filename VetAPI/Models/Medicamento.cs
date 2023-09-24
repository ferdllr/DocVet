namespace VetAPI.Models;

public class Medicamento
{
    public enum Tipo
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

    public int Id { get; set; }
    public string Nome { get; set; }
    public Tipo TipoMedicamento { get; set; }
    public int Miligrama { get; set; }
    public Tarja TarjaMedicamento { get; set; }
    public DateTime Ciclo { get; set; }

}