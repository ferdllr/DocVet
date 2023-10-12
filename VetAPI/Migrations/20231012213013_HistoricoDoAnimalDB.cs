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
                table: "Prontuarios",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HistoricoDoAnimals",
                columns: table => new
                {
                    HistoricoDoAnimalId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoDoAnimals", x => x.HistoricoDoAnimalId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prontuarios_HistoricoDoAnimalId",
                table: "Prontuarios",
                column: "HistoricoDoAnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prontuarios_HistoricoDoAnimals_HistoricoDoAnimalId",
                table: "Prontuarios",
                column: "HistoricoDoAnimalId",
                principalTable: "HistoricoDoAnimals",
                principalColumn: "HistoricoDoAnimalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prontuarios_HistoricoDoAnimals_HistoricoDoAnimalId",
                table: "Prontuarios");

            migrationBuilder.DropTable(
                name: "HistoricoDoAnimals");

            migrationBuilder.DropIndex(
                name: "IX_Prontuarios_HistoricoDoAnimalId",
                table: "Prontuarios");

            migrationBuilder.DropColumn(
                name: "HistoricoDoAnimalId",
                table: "Prontuarios");
        }
    }
}
