
using Microsoft.EntityFrameworkCore;
using VetAPI.Models;

namespace VetAPI.Data
{
    public class AppDbContext : DbContext
        {
            public DbSet<Contato> Contatos { get; set; }
            public DbSet<Funcionario> Funcionarios{get; set;}
            public DbSet<Animal> Animais {get;set;}
            public DbSet<Tutor> Tutors {get;set;}
            public DbSet<Exame> Exames {get;set;}
            public DbSet<Procedimento> Procedimentos{get;set;}
            public DbSet<EstadoDoAnimal> EstadoDoAnimals{get;set;}
            public DbSet<Medicamento> Medicamentos{get;set;}
            public DbSet<Prontuario> Prontuarios{get;set;}
            public DbSet<HistoricoDoAnimal> HistoricoDoAnimals{get;set;}
            public DbSet<Vacina> Vacinas{get;set;}
            public DbSet<Alimentacao> Alimentacaos{get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=Vetdb.db; Cache=Shared");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contato>().HasKey(c => c.ContatoId);
            modelBuilder.Entity<Funcionario>().HasKey(c => c.FuncionarioId);
            modelBuilder.Entity<Animal>().HasKey(c => c.AnimalId);
            modelBuilder.Entity<Tutor>().HasKey(c => c.TutorId);
            modelBuilder.Entity<Exame>().HasKey(c => c.ExameId);
            modelBuilder.Entity<Procedimento>().HasKey(c => c.ProcedimentoId);
            modelBuilder.Entity<EstadoDoAnimal>().HasKey(c => c.EstadoDoAnimalId);
            modelBuilder.Entity<Medicamento>().HasKey(c => c.MedicamentoId);
            modelBuilder.Entity<Prontuario>().HasKey(c => c.ProntuarioId);
            modelBuilder.Entity<HistoricoDoAnimal>().HasKey(c => c.HistoricoDoAnimalId);
            modelBuilder.Entity<Vacina>().HasKey(c => c.VacinaId);
            modelBuilder.Entity<Alimentacao>().HasKey(c => c.AlimentacaoId);
        }
    }
}

