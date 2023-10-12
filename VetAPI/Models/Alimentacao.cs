namespace VetAPI.Models
{
    public class Alimentacao
    {
        public int AlimentacaoId { get; set; }
        public DateTime DataHoraAlimentacao { get; set; }
        public string? TipoAlimento { get; set; }
        public decimal QuantidadeFornecida { get; set; }
        public string? FrequenciaRefeicoes { get; set; }
        public string? Observacoes { get; set; }

        // Relação com o animal (caso cada registro de alimentação seja associado a um animal específico)
        public Animal? Animal { get; set; }
    }
}