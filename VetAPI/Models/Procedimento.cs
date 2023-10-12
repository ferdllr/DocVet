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
    public int? ProcedimentoId { get; set; }
    public string? Nome { get; set; }
    public TipoProc? TipoProcedimento { get; set; }
    public string? Descricao { get; set; }
}