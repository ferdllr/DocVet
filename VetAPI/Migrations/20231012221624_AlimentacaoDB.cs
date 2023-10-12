using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetAPI.Migrations
{
    /// <inheritdoc />
    public partial class AlimentacaoDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacinas_Animais_AnimalId",
                table: "Vacinas");

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "Vacinas",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateTable(
                name: "Alimentacaos",
                columns: table => new
                {
                    AlimentacaoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataHoraAlimentacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TipoAlimento = table.Column<string>(type: "TEXT", nullable: true),
                    QuantidadeFornecida = table.Column<decimal>(type: "TEXT", nullable: false),
                    FrequenciaRefeicoes = table.Column<string>(type: "TEXT", nullable: true),
                    Observacoes = table.Column<string>(type: "TEXT", nullable: true),
                    AnimalId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alimentacaos", x => x.AlimentacaoId);
                    table.ForeignKey(
                        name: "FK_Alimentacaos_Animais_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animais",
                        principalColumn: "AnimalId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alimentacaos_AnimalId",
                table: "Alimentacaos",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacinas_Animais_AnimalId",
                table: "Vacinas",
                column: "AnimalId",
                principalTable: "Animais",
                principalColumn: "AnimalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacinas_Animais_AnimalId",
                table: "Vacinas");

            migrationBuilder.DropTable(
                name: "Alimentacaos");

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "Vacinas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacinas_Animais_AnimalId",
                table: "Vacinas",
                column: "AnimalId",
                principalTable: "Animais",
                principalColumn: "AnimalId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
