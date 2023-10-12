using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetAPI.Migrations
{
    /// <inheritdoc />
    public partial class IdCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Funcionarios",
                newName: "FuncionarioId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Contatos",
                newName: "ContatoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FuncionarioId",
                table: "Funcionarios",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ContatoId",
                table: "Contatos",
                newName: "Id");
        }
    }
}
