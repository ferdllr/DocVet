using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetAPI.Migrations
{
    /// <inheritdoc />
    public partial class ProntuarioDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProntuarioId",
                table: "Medicamentos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProntuarioId",
                table: "EstadoDoAnimals",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Prontuarios",
                columns: table => new
                {
                    ProntuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnimalId = table.Column<int>(type: "INTEGER", nullable: true),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prontuarios", x => x.ProntuarioId);
                    table.ForeignKey(
                        name: "FK_Prontuarios_Animais_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animais",
                        principalColumn: "AnimalId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicamentos_ProntuarioId",
                table: "Medicamentos",
                column: "ProntuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_EstadoDoAnimals_ProntuarioId",
                table: "EstadoDoAnimals",
                column: "ProntuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Prontuarios_AnimalId",
                table: "Prontuarios",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_EstadoDoAnimals_Prontuarios_ProntuarioId",
                table: "EstadoDoAnimals",
                column: "ProntuarioId",
                principalTable: "Prontuarios",
                principalColumn: "ProntuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicamentos_Prontuarios_ProntuarioId",
                table: "Medicamentos",
                column: "ProntuarioId",
                principalTable: "Prontuarios",
                principalColumn: "ProntuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstadoDoAnimals_Prontuarios_ProntuarioId",
                table: "EstadoDoAnimals");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicamentos_Prontuarios_ProntuarioId",
                table: "Medicamentos");

            migrationBuilder.DropTable(
                name: "Prontuarios");

            migrationBuilder.DropIndex(
                name: "IX_Medicamentos_ProntuarioId",
                table: "Medicamentos");

            migrationBuilder.DropIndex(
                name: "IX_EstadoDoAnimals_ProntuarioId",
                table: "EstadoDoAnimals");

            migrationBuilder.DropColumn(
                name: "ProntuarioId",
                table: "Medicamentos");

            migrationBuilder.DropColumn(
                name: "ProntuarioId",
                table: "EstadoDoAnimals");
        }
    }
}
