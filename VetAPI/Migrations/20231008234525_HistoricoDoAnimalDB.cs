using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetAPI.Migrations
{
    /// <inheritdoc />
    public partial class HistoricoDoAnimalDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HistoricoDoAnimalId",
                table: "Prontuario",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Exame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoExame = table.Column<int>(type: "INTEGER", nullable: true),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Observacao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exame", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoDoAnimal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TutorId = table.Column<int>(type: "INTEGER", nullable: true),
                    AnimalId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoDoAnimal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoDoAnimal_Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animal",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoricoDoAnimal_Tutor_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Tutor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prontuario_HistoricoDoAnimalId",
                table: "Prontuario",
                column: "HistoricoDoAnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoDoAnimal_AnimalId",
                table: "HistoricoDoAnimal",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoDoAnimal_TutorId",
                table: "HistoricoDoAnimal",
                column: "TutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prontuario_HistoricoDoAnimal_HistoricoDoAnimalId",
                table: "Prontuario",
                column: "HistoricoDoAnimalId",
                principalTable: "HistoricoDoAnimal",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prontuario_HistoricoDoAnimal_HistoricoDoAnimalId",
                table: "Prontuario");

            migrationBuilder.DropTable(
                name: "Exame");

            migrationBuilder.DropTable(
                name: "HistoricoDoAnimal");

            migrationBuilder.DropIndex(
                name: "IX_Prontuario_HistoricoDoAnimalId",
                table: "Prontuario");

            migrationBuilder.DropColumn(
                name: "HistoricoDoAnimalId",
                table: "Prontuario");
        }
    }
}
