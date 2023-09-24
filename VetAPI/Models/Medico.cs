namespace VetAPI.Models;

public class Medico
{
    public enum Especialidade
    {
        Cardiologia,
        Neurologia,
        Endocrinologia
    }
    public Especialidade EspecialidadeMedica { get; set;}
    
}