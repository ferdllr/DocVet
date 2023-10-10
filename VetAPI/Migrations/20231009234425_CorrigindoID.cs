using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetAPI.Migrations
{
    /// <inheritdoc />
    public partial class CorrigindoID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Tutor_tutorId",
                table: "Animal");

            migrationBuilder.RenameColumn(
                name: "horario",
                table: "EstadoAnimal",
                newName: "Horario");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "EstadoAnimal",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "tutorId",
                table: "Animal",
                newName: "TutorId");

            migrationBuilder.RenameIndex(
                name: "IX_Animal_tutorId",
                table: "Animal",
                newName: "IX_Animal_TutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Tutor_TutorId",
                table: "Animal",
                column: "TutorId",
                principalTable: "Tutor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Tutor_TutorId",
                table: "Animal");

            migrationBuilder.RenameColumn(
                name: "Horario",
                table: "EstadoAnimal",
                newName: "horario");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "EstadoAnimal",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TutorId",
                table: "Animal",
                newName: "tutorId");

            migrationBuilder.RenameIndex(
                name: "IX_Animal_TutorId",
                table: "Animal",
                newName: "IX_Animal_tutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Tutor_tutorId",
                table: "Animal",
                column: "tutorId",
                principalTable: "Tutor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
