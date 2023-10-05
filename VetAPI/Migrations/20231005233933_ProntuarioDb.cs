using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetAPI.Migrations
{
    /// <inheritdoc />
    public partial class ProntuarioDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProntuarioId",
                table: "Medicamento",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProntuarioId",
                table: "EstadoAnimal",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Prontuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnimalId = table.Column<int>(type: "INTEGER", nullable: false),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prontuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prontuario_Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicamento_ProntuarioId",
                table: "Medicamento",
                column: "ProntuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_EstadoAnimal_ProntuarioId",
                table: "EstadoAnimal",
                column: "ProntuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Prontuario_AnimalId",
                table: "Prontuario",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_EstadoAnimal_Prontuario_ProntuarioId",
                table: "EstadoAnimal",
                column: "ProntuarioId",
                principalTable: "Prontuario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicamento_Prontuario_ProntuarioId",
                table: "Medicamento",
                column: "ProntuarioId",
                principalTable: "Prontuario",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstadoAnimal_Prontuario_ProntuarioId",
                table: "EstadoAnimal");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicamento_Prontuario_ProntuarioId",
                table: "Medicamento");

            migrationBuilder.DropTable(
                name: "Prontuario");

            migrationBuilder.DropIndex(
                name: "IX_Medicamento_ProntuarioId",
                table: "Medicamento");

            migrationBuilder.DropIndex(
                name: "IX_EstadoAnimal_ProntuarioId",
                table: "EstadoAnimal");

            migrationBuilder.DropColumn(
                name: "ProntuarioId",
                table: "Medicamento");

            migrationBuilder.DropColumn(
                name: "ProntuarioId",
                table: "EstadoAnimal");
        }
    }
}
