using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetAPI.Migrations
{
    /// <inheritdoc />
    public partial class newdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    ContatoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.ContatoId);
                });

            migrationBuilder.CreateTable(
                name: "Exames",
                columns: table => new
                {
                    ExameId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoExame = table.Column<int>(type: "INTEGER", nullable: true),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Observacao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exames", x => x.ExameId);
                });

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

            migrationBuilder.CreateTable(
                name: "Procedimentos",
                columns: table => new
                {
                    ProcedimentoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    TipoProcedimento = table.Column<int>(type: "INTEGER", nullable: true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedimentos", x => x.ProcedimentoId);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Cpf = table.Column<string>(type: "TEXT", nullable: true),
                    ContatoId = table.Column<int>(type: "INTEGER", nullable: true),
                    TipoFuncionario = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.FuncionarioId);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Contatos_ContatoId",
                        column: x => x.ContatoId,
                        principalTable: "Contatos",
                        principalColumn: "ContatoId");
                });

            migrationBuilder.CreateTable(
                name: "Tutors",
                columns: table => new
                {
                    TutorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Cpf = table.Column<string>(type: "TEXT", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ContatoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutors", x => x.TutorId);
                    table.ForeignKey(
                        name: "FK_Tutors_Contatos_ContatoId",
                        column: x => x.ContatoId,
                        principalTable: "Contatos",
                        principalColumn: "ContatoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animais",
                columns: table => new
                {
                    AnimalId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    EspecieAnimal = table.Column<int>(type: "INTEGER", nullable: false),
                    Raca = table.Column<string>(type: "TEXT", nullable: true),
                    Idade = table.Column<int>(type: "INTEGER", nullable: false),
                    SexoDoAnimal = table.Column<int>(type: "INTEGER", nullable: false),
                    Peso = table.Column<float>(type: "REAL", nullable: false),
                    TutorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animais", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK_Animais_Tutors_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Tutors",
                        principalColumn: "TutorId");
                });

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

            migrationBuilder.CreateTable(
                name: "Prontuarios",
                columns: table => new
                {
                    ProntuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnimalId = table.Column<int>(type: "INTEGER", nullable: true),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HistoricoDoAnimalId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prontuarios", x => x.ProntuarioId);
                    table.ForeignKey(
                        name: "FK_Prontuarios_Animais_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animais",
                        principalColumn: "AnimalId");
                    table.ForeignKey(
                        name: "FK_Prontuarios_HistoricoDoAnimals_HistoricoDoAnimalId",
                        column: x => x.HistoricoDoAnimalId,
                        principalTable: "HistoricoDoAnimals",
                        principalColumn: "HistoricoDoAnimalId");
                });

            migrationBuilder.CreateTable(
                name: "Vacinas",
                columns: table => new
                {
                    VacinaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    DataVacinação = table.Column<DateTime>(type: "TEXT", nullable: false),
                    VeterinárioResponsável = table.Column<string>(type: "TEXT", nullable: true),
                    Lote = table.Column<string>(type: "TEXT", nullable: true),
                    PróximaDataReforço = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AnimalId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacinas", x => x.VacinaId);
                    table.ForeignKey(
                        name: "FK_Vacinas_Animais_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animais",
                        principalColumn: "AnimalId");
                });

            migrationBuilder.CreateTable(
                name: "EstadoDoAnimals",
                columns: table => new
                {
                    EstadoDoAnimalId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GravidadeDoAnimal = table.Column<int>(type: "INTEGER", nullable: false),
                    Horario = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    ProntuarioId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoDoAnimals", x => x.EstadoDoAnimalId);
                    table.ForeignKey(
                        name: "FK_EstadoDoAnimals_Prontuarios_ProntuarioId",
                        column: x => x.ProntuarioId,
                        principalTable: "Prontuarios",
                        principalColumn: "ProntuarioId");
                });

            migrationBuilder.CreateTable(
                name: "Medicamentos",
                columns: table => new
                {
                    MedicamentoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    TipoMedicamento = table.Column<int>(type: "INTEGER", nullable: false),
                    Miligrama = table.Column<float>(type: "REAL", nullable: false),
                    TarjaMedicamento = table.Column<int>(type: "INTEGER", nullable: false),
                    Ciclo = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ProntuarioId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamentos", x => x.MedicamentoId);
                    table.ForeignKey(
                        name: "FK_Medicamentos_Prontuarios_ProntuarioId",
                        column: x => x.ProntuarioId,
                        principalTable: "Prontuarios",
                        principalColumn: "ProntuarioId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alimentacaos_AnimalId",
                table: "Alimentacaos",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Animais_TutorId",
                table: "Animais",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_EstadoDoAnimals_ProntuarioId",
                table: "EstadoDoAnimals",
                column: "ProntuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_ContatoId",
                table: "Funcionarios",
                column: "ContatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamentos_ProntuarioId",
                table: "Medicamentos",
                column: "ProntuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Prontuarios_AnimalId",
                table: "Prontuarios",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Prontuarios_HistoricoDoAnimalId",
                table: "Prontuarios",
                column: "HistoricoDoAnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Tutors_ContatoId",
                table: "Tutors",
                column: "ContatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacinas_AnimalId",
                table: "Vacinas",
                column: "AnimalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alimentacaos");

            migrationBuilder.DropTable(
                name: "EstadoDoAnimals");

            migrationBuilder.DropTable(
                name: "Exames");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Medicamentos");

            migrationBuilder.DropTable(
                name: "Procedimentos");

            migrationBuilder.DropTable(
                name: "Vacinas");

            migrationBuilder.DropTable(
                name: "Prontuarios");

            migrationBuilder.DropTable(
                name: "Animais");

            migrationBuilder.DropTable(
                name: "HistoricoDoAnimals");

            migrationBuilder.DropTable(
                name: "Tutors");

            migrationBuilder.DropTable(
                name: "Contatos");
        }
    }
}
