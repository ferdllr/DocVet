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
    [Migration("20231012024028_IdCorrection")]
    partial class IdCorrection
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

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

            modelBuilder.Entity("VetAPI.Models.Funcionario", b =>
                {
                    b.HasOne("VetAPI.Models.Contato", "Contato")
                        .WithMany()
                        .HasForeignKey("ContatoId");

                    b.Navigation("Contato");
                });
#pragma warning restore 612, 618
        }
    }
}
