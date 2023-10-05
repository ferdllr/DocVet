using VetAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace VetAPI.Data;

public class DocVetDbContext : DbContext
{
    //adicionar classe na tabela (PRECISA DE PRIMARY KEY)
    public DbSet<Funcionario>? Funcionario { get; set; }
    public DbSet<Contato>? Contato { get; set;}
    public DbSet<Medicamento>? Medicamento {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=DocVet.db;Cache=Shared");
    }

}