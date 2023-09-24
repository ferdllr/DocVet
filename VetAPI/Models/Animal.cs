namespace VetAPI.Models;

public class Animal
{
    private Sexo sexoDoAnimal;

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

    public int Id { get; set; }
    public string Nome { get; set; }
    public Especie EspecieAnimal { get; set; }
    public string Raca { get; set; }
    public int Idade { get; set; }
    public Sexo SexoDoAnimal { get; set; }
    public Cliente Cliente { get; set; }
    public float Peso { get; set; }



}