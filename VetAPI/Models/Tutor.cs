namespace VetAPI.Models
{
    public class Tutor
    {
        public int TutorId { get; set;}
        public string? Nome { get; set;}
        public string? Cpf { get; set;}
        public DateTime? DataNascimento { get; set;}
        public string? Telefone {get;set;}
        public string? Email{get;set;}
        public List<Animal>? Animais { get; set; } = new List<Animal>();
    }
}

