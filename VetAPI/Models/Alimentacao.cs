using System;
using System.ComponentModel.DataAnnotations;

namespace VetAPI.Models
{
    public class Alimentacao
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Data e Hora da Alimentação")]
        [DataType(DataType.DateTime)]
        public DateTime DataHoraAlimentacao { get; set; }

        [Display(Name = "Tipo de Alimento")]
        public string TipoAlimento { get; set; }

        [Display(Name = "Quantidade Fornecida")]
        public decimal QuantidadeFornecida { get; set; }

        [Display(Name = "Frequência das Refeições")]
        public string FrequenciaRefeicoes { get; set; }

        [Display(Name = "Observações")]
        public string Observacoes { get; set; }

        // Relação com o animal (caso cada registro de alimentação seja associado a um animal específico)
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
    }
}
