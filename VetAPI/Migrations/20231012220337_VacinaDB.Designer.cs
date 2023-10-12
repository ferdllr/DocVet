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
    [Migration("20231012220337_VacinaDB")]
    partial class VacinaDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("VetAPI.Models.Animal", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EspecieAnimal")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Idade")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<float>("Peso")
                        .HasColumnType("REAL");

                    b.Property<string>("Raca")
                        .HasColumnType("TEXT");

                    b.Property<int>("SexoDoAnimal")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TutorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AnimalId");

                    b.HasIndex("TutorId");

                    b.ToTable("Animais");
                });

            modelBuilder.Entity("VetAPI.Models.Contato", b =>
                {
                    b.Property<int>("ContatoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("ContatoId");

                    b.ToTable("Contatos");
                });

            modelBuilder.Entity("VetAPI.Models.EstadoDoAnimal", b =>
                {
                    b.Property<int>("EstadoDoAnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<int>("GravidadeDoAnimal")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Horario")
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

                    b.Property<int?>("TipoExame")
                        .HasColumnType("INTEGER");

                    b.HasKey("ExameId");

                    b.ToTable("Exames");
                });

            modelBuilder.Entity("VetAPI.Models.Funcionario", b =>
                {
                    b.Property<int>("FuncionarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ContatoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int>("TipoFuncionario")
                        .HasColumnType("INTEGER");

                    b.HasKey("FuncionarioId");

                    b.HasIndex("ContatoId");

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

                    b.Property<int>("TarjaMedicamento")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TipoMedicamento")
                        .HasColumnType("INTEGER");

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

                    b.Property<int?>("TipoProcedimento")
                        .HasColumnType("INTEGER");

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

                    b.Property<int>("ContatoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TutorId");

                    b.HasIndex("ContatoId");

                    b.ToTable("Tutors");
                });

            modelBuilder.Entity("VetAPI.Models.Vacina", b =>
                {
                    b.Property<int>("VacinaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnimalId")
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

            modelBuilder.Entity("VetAPI.Models.Funcionario", b =>
                {
                    b.HasOne("VetAPI.Models.Contato", "Contato")
                        .WithMany()
                        .HasForeignKey("ContatoId");

                    b.Navigation("Contato");
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

            modelBuilder.Entity("VetAPI.Models.Tutor", b =>
                {
                    b.HasOne("VetAPI.Models.Contato", "Contato")
                        .WithMany()
                        .HasForeignKey("ContatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contato");
                });

            modelBuilder.Entity("VetAPI.Models.Vacina", b =>
                {
                    b.HasOne("VetAPI.Models.Animal", "Animal")
                        .WithMany()
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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