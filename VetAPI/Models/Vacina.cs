namespace VetAPI.Models
{
    public class Vacina
    {
        public int VacinaId { get; set; }

        public string? Nome { get; set; }
        public DateTime DataVacinação { get; set; }
        public string? VeterinárioResponsável { get; set; }

        public string? Lote { get; set; }
        public DateTime PróximaDataReforço { get; set; }

        // Relação com o animal (caso cada vacina seja associada a um animal específico)
        public Animal? Animal { get; set; }
    }
}