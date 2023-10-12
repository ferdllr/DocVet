namespace VetAPI.Models
{
    public class Animal
{

    public enum Especie
    {
        Canino,
        Felino
    }
    public enum Sexo
    {
        Macho,
        Femea
    }
    public int AnimalId { get; set; }
    public string? Nome { get; set; }
    public Especie EspecieAnimal { get; set; }
    public string? Raca { get; set; }
    public int Idade { get; set; }
    public Sexo SexoDoAnimal { get; set; }
    public float Peso { get; set; }

}
}