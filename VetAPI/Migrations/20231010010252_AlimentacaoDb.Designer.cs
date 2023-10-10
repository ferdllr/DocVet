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
    [DbContext(typeof(DocVetDbContext))]
    [Migration("20231010010252_AlimentacaoDb")]
    partial class AlimentacaoDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("VetAPI.Models.Alimentacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnimalId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataHoraAlimentacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("FrequenciaRefeicoes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Observacoes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("QuantidadeFornecida")
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoAlimento")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.ToTable("Alimentacao");
                });

            modelBuilder.Entity("VetAPI.Models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EspecieAnimal")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Idade")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("Peso")
                        .HasColumnType("REAL");

                    b.Property<string>("Raca")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SexoDoAnimal")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TutorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TutorId");

                    b.ToTable("Animal");
                });

            modelBuilder.Entity("VetAPI.Models.Contato", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefones")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Contato");
                });

            modelBuilder.Entity("VetAPI.Models.EstadoAnimal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GravidadeDoAnimal")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Horario")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProntuarioId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProntuarioId");

                    b.ToTable("EstadoAnimal");
                });

            modelBuilder.Entity("VetAPI.Models.Exame", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Data")
                        .HasColumnType("TEXT");

                    b.Property<string>("Observacao")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TipoExame")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Exame");
                });

            modelBuilder.Entity("VetAPI.Models.Funcionario", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ContatoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TipoFuncionario")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ContatoId");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("VetAPI.Models.HistoricoDoAnimal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AnimalId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TutorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("TutorId");

                    b.ToTable("HistoricoDoAnimal");
                });

            modelBuilder.Entity("VetAPI.Models.Medicamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Ciclo")
                        .HasColumnType("TEXT");

                    b.Property<float>("Miligrama")
                        .HasColumnType("REAL");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProntuarioId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TarjaMedicamento")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TipoMedicamento")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProntuarioId");

                    b.ToTable("Medicamento");
                });

            modelBuilder.Entity("VetAPI.Models.Procedimento", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TipoProcedimento")
                        .HasColumnType("INTEGER");

                    b.Property<string>("descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Procedimento");
                });

            modelBuilder.Entity("VetAPI.Models.Prontuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnimalId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Data")
                        .HasColumnType("TEXT");

                    b.Property<int?>("HistoricoDoAnimalId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("HistoricoDoAnimalId");

                    b.ToTable("Prontuario");
                });

            modelBuilder.Entity("VetAPI.Models.Tutor", b =>
                {
                    b.Property<int>("Id")
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

                    b.HasKey("Id");

                    b.HasIndex("ContatoId");

                    b.ToTable("Tutor");
                });

            modelBuilder.Entity("VetAPI.Models.Vacina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnimalId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataVacinação")
                        .HasColumnType("TEXT");

                    b.Property<string>("Lote")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PróximaDataReforço")
                        .HasColumnType("TEXT");

                    b.Property<string>("VeterinárioResponsável")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.ToTable("Vacina");
                });

            modelBuilder.Entity("VetAPI.Models.Alimentacao", b =>
                {
                    b.HasOne("VetAPI.Models.Animal", "Animal")
                        .WithMany()
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");
                });

            modelBuilder.Entity("VetAPI.Models.Animal", b =>
                {
                    b.HasOne("VetAPI.Models.Tutor", "Tutor")
                        .WithMany()
                        .HasForeignKey("TutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("VetAPI.Models.EstadoAnimal", b =>
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

            modelBuilder.Entity("VetAPI.Models.HistoricoDoAnimal", b =>
                {
                    b.HasOne("VetAPI.Models.Animal", "Animal")
                        .WithMany()
                        .HasForeignKey("AnimalId");

                    b.HasOne("VetAPI.Models.Tutor", "Tutor")
                        .WithMany()
                        .HasForeignKey("TutorId");

                    b.Navigation("Animal");

                    b.Navigation("Tutor");
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
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
#pragma warning restore 612, 618
        }
    }
}