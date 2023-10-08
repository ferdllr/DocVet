using VetAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace VetAPI.Data;

public class DocVetDbContext : DbContext
{
    //adicionar classe na tabela (PRECISA DE PRIMARY KEY)
    public DbSet<Funcionario>? Funcionario { get; set; }
    public DbSet<Contato>? Contato { get; set;}
    public DbSet<Medicamento>? Medicamento {get; set;}
    public DbSet<Animal>? Animal { get; set; }
    public DbSet<EstadoAnimal>? EstadoAnimal { get; set; }
    public DbSet<Prontuario>? Prontuario { get; set; }
    public DbSet<Tutor>? Tutor { get; set; }
    public DbSet<Exame>? Exame {get; set; }
    public DbSet<HistoricoDoAnimal>? HistoricoDoAnimal{get;set;}
    public DbSet<Procedimento>? Procedimento{get;set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=DocVet.db;Cache=Shared");
    }

}