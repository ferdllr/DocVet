﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VetAPI.Data;

#nullable disable

namespace VetAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231122020704_OtheMigrationsEight")]
    partial class OtheMigrationsEight
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("VetAPI.Models.Alimentacao", b =>
                {
                    b.Property<int>("AlimentacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AnimalId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataAlimentacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("FrequenciaRefeicoes")
                        .HasColumnType("TEXT");

                    b.Property<string>("HoraAlimentacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Observacoes")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("QuantidadeFornecida")
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoAlimento")
                        .HasColumnType("TEXT");

                    b.HasKey("AlimentacaoId");

                    b.HasIndex("AnimalId");

                    b.ToTable("Alimentacaos");
                });

            modelBuilder.Entity("VetAPI.Models.Animal", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EspecieAnimal")
                        .HasColumnType("TEXT");

                    b.Property<int>("Idade")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<float>("Peso")
                        .HasColumnType("REAL");

                    b.Property<string>("Raca")
                        .HasColumnType("TEXT");

                    b.Property<string>("SexoDoAnimal")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TutorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AnimalId");

                    b.HasIndex("TutorId");

                    b.ToTable("Animais");
                });

            modelBuilder.Entity("VetAPI.Models.EstadoDoAnimal", b =>
                {
                    b.Property<int>("EstadoDoAnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("GravidadeDoAnimal")
                        .HasColumnType("TEXT");

                    b.Property<string>("Horario")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProntuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EstadoDoAnimalId");

                    b.HasIndex("ProntuarioId");

                    b.ToTable("EstadoDoAnimals");
                });

            modelBuilder.Entity("VetAPI.Models.Exame", b =>
                {
                    b.Property<int?>("ExameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Data")
                        .HasColumnType("TEXT");

                    b.Property<string>("Observacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoExame")
                        .HasColumnType("TEXT");

                    b.HasKey("ExameId");

                    b.ToTable("Exames");
                });

            modelBuilder.Entity("VetAPI.Models.Funcionario", b =>
                {
                    b.Property<int>("FuncionarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoFuncionario")
                        .HasColumnType("TEXT");

                    b.HasKey("FuncionarioId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("VetAPI.Models.HistoricoDoAnimal", b =>
                {
                    b.Property<int>("HistoricoDoAnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("HistoricoDoAnimalId");

                    b.ToTable("HistoricoDoAnimals");
                });

            modelBuilder.Entity("VetAPI.Models.Medicamento", b =>
                {
                    b.Property<int>("MedicamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Ciclo")
                        .HasColumnType("TEXT");

                    b.Property<float>("Miligrama")
                        .HasColumnType("REAL");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProntuarioId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TarjaMedicamento")
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoMedicamento")
                        .HasColumnType("TEXT");

                    b.HasKey("MedicamentoId");

                    b.HasIndex("ProntuarioId");

                    b.ToTable("Medicamentos");
                });

            modelBuilder.Entity("VetAPI.Models.Procedimento", b =>
                {
                    b.Property<int?>("ProcedimentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoProcedimento")
                        .HasColumnType("TEXT");

                    b.HasKey("ProcedimentoId");

                    b.ToTable("Procedimentos");
                });

            modelBuilder.Entity("VetAPI.Models.Prontuario", b =>
                {
                    b.Property<int>("ProntuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AnimalId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Data")
                        .HasColumnType("TEXT");

                    b.Property<int?>("HistoricoDoAnimalId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProntuarioId");

                    b.HasIndex("AnimalId");

                    b.HasIndex("HistoricoDoAnimalId");

                    b.ToTable("Prontuarios");
                });

            modelBuilder.Entity("VetAPI.Models.Tutor", b =>
                {
                    b.Property<int>("TutorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("TutorId");

                    b.ToTable("Tutors");
                });

            modelBuilder.Entity("VetAPI.Models.Vacina", b =>
                {
                    b.Property<int>("VacinaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AnimalId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataVacinação")
                        .HasColumnType("TEXT");

                    b.Property<string>("Lote")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PróximaDataReforço")
                        .HasColumnType("TEXT");

                    b.Property<string>("VeterinárioResponsável")
                        .HasColumnType("TEXT");

                    b.HasKey("VacinaId");

                    b.HasIndex("AnimalId");

                    b.ToTable("Vacinas");
                });

            modelBuilder.Entity("VetAPI.Models.Alimentacao", b =>
                {
                    b.HasOne("VetAPI.Models.Animal", "Animal")
                        .WithMany()
                        .HasForeignKey("AnimalId");

                    b.Navigation("Animal");
                });

            modelBuilder.Entity("VetAPI.Models.Animal", b =>
                {
                    b.HasOne("VetAPI.Models.Tutor", null)
                        .WithMany("Animais")
                        .HasForeignKey("TutorId");
                });

            modelBuilder.Entity("VetAPI.Models.EstadoDoAnimal", b =>
                {
                    b.HasOne("VetAPI.Models.Prontuario", null)
                        .WithMany("EstadosAnimais")
                        .HasForeignKey("ProntuarioId");
                });

            modelBuilder.Entity("VetAPI.Models.Medicamento", b =>
                {
                    b.HasOne("VetAPI.Models.Prontuario", null)
                        .WithMany("Medicamentos")
                        .HasForeignKey("ProntuarioId");
                });

            modelBuilder.Entity("VetAPI.Models.Prontuario", b =>
                {
                    b.HasOne("VetAPI.Models.Animal", "Animal")
                        .WithMany()
                        .HasForeignKey("AnimalId");

                    b.HasOne("VetAPI.Models.HistoricoDoAnimal", null)
                        .WithMany("Prontuarios")
                        .HasForeignKey("HistoricoDoAnimalId");

                    b.Navigation("Animal");
                });

            modelBuilder.Entity("VetAPI.Models.Vacina", b =>
                {
                    b.HasOne("VetAPI.Models.Animal", "Animal")
                        .WithMany()
                        .HasForeignKey("AnimalId");

                    b.Navigation("Animal");
                });

            modelBuilder.Entity("VetAPI.Models.HistoricoDoAnimal", b =>
                {
                    b.Navigation("Prontuarios");
                });

            modelBuilder.Entity("VetAPI.Models.Prontuario", b =>
                {
                    b.Navigation("EstadosAnimais");

                    b.Navigation("Medicamentos");
                });

            modelBuilder.Entity("VetAPI.Models.Tutor", b =>
                {
                    b.Navigation("Animais");
                });
#pragma warning restore 612, 618
        }
    }
}
