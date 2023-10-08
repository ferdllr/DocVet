using System.ComponentModel.DataAnnotations;

namespace VetAPI.Models;

public class Procedimento
{
    public enum TipoProc
    {
        Curativo,
        Cistosintese,
        Toracocintese
    }
    [Key]
    public int? Id { get; set; }
    public string? nome { get; set; }
    public TipoProc? TipoProcedimento { get; set; }
    public string? descricao { get; set; }
}