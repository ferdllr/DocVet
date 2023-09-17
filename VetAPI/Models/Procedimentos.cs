namespace VetAPI.Models;

public class Procedimentos
{
    public int id { get; set; }
    public string nome { get; set; }
    public enum tipo { get; set; }
    public string descricao { get; set; }
}