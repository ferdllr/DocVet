namespace VetAPI.Models;

public class Procedimento
{
    public enum Tipo
    {
        Curativo,
        Cistosintese,
        Toracocintese
    }

    public int id { get; set; }
    public string nome { get; set; }
    public Tipo TipoProcedimento { get; set; }
    public string descricao { get; set; }
}