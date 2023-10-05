﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VetAPI.Data;

#nullable disable

namespace VetAPI.Migrations
{
    [DbContext(typeof(DocVetDbContext))]
    partial class DocVetDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

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

                    b.Property<int>("tutorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("tutorId");

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
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GravidadeDoAnimal")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProntuarioId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("horario")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("ProntuarioId");

                    b.ToTable("EstadoAnimal");
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

            modelBuilder.Entity("VetAPI.Models.Medicamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Ciclo")
                        .HasColumnType("TEXT");

                    b.Property<int>("Miligrama")
                        .HasColumnType("INTEGER");

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

            modelBuilder.Entity("VetAPI.Models.Prontuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnimalId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Data")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

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

            modelBuilder.Entity("VetAPI.Models.Animal", b =>
                {
                    b.HasOne("VetAPI.Models.Tutor", "tutor")
                        .WithMany()
                        .HasForeignKey("tutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tutor");
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

            modelBuilder.Entity("VetAPI.Models.Prontuario", b =>
                {
                    b.Navigation("EstadosAnimais");

                    b.Navigation("Medicamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
