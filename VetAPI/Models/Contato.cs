using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace VetAPI.Models;
public class Contato
{
    //declaração de chave primaria
    [Key]
    public int? Id { get; set; }
    public string? Telefones { get; set; }
    public string? Email{ get; set; }
    
}