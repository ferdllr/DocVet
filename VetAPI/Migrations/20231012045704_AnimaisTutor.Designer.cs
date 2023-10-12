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
    [Migration("20231012045704_AnimaisTutor")]
    partial class AnimaisTutor
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

            modelBuilder.Entity("VetAPI.Models.Animal", b =>
                {
                    b.HasOne("VetAPI.Models.Tutor", null)
                        .WithMany("Animais")
                        .HasForeignKey("TutorId");
                });

            modelBuilder.Entity("VetAPI.Models.Funcionario", b =>
                {
                    b.HasOne("VetAPI.Models.Contato", "Contato")
                        .WithMany()
                        .HasForeignKey("ContatoId");

                    b.Navigation("Contato");
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

            modelBuilder.Entity("VetAPI.Models.Tutor", b =>
                {
                    b.Navigation("Animais");
                });
#pragma warning restore 612, 618
        }
    }
}
