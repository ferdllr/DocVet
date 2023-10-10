using System;
using System.ComponentModel.DataAnnotations;

namespace VetAPI.Models
{
    public class Vacina
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        [Display(Name = "Data da Vacinação")]
        [DataType(DataType.Date)]
        public DateTime DataVacinação { get; set; }

        [Display(Name = "Veterinário Responsável")]
        public string VeterinárioResponsável { get; set; }

        public string Lote { get; set; }

        [Display(Name = "Próxima Data de Reforço")]
        [DataType(DataType.Date)]
        public DateTime PróximaDataReforço { get; set; }

        // Relação com o animal (caso cada vacina seja associada a um animal específico)
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
    }
}
