using System.ComponentModel.DataAnnotations;

namespace VetAPI.Models;

public class Procedimento
{
    public int? ProcedimentoId { get; set; }
    public string? Nome { get; set; }
    public string? TipoProcedimento { get; set; }
    public string? Descricao { get; set; }
}