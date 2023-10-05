using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetAPI.Migrations
{
    /// <inheritdoc />
    public partial class EstadoAnimalDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadoAnimal",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GravidadeDoAnimal = table.Column<int>(type: "INTEGER", nullable: false),
                    horario = table.Column<DateTime>(type: "TEXT", nullable: false),
                    descricao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoAnimal", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstadoAnimal");
        }
    }
}
