using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace health_system_api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autorizacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autorizacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doenca",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doenca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingestao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingestao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    Genero = table.Column<bool>(nullable: false),
                    Idade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    AutorizacaoId = table.Column<int>(nullable: false),
                    CRM = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Autorizacao_AutorizacaoId",
                        column: x => x.AutorizacaoId,
                        principalTable: "Autorizacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Remedio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<int>(nullable: false),
                    MedidaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remedio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Remedio_Ingestao_MedidaId",
                        column: x => x.MedidaId,
                        principalTable: "Ingestao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    diaConsulta = table.Column<DateTime>(nullable: false),
                    PacienteId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consulta_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consulta_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diagnostico",
                columns: table => new
                {
                    DoencaId = table.Column<int>(nullable: false),
                    ConsultaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnostico", x => new { x.DoencaId, x.ConsultaId });
                    table.ForeignKey(
                        name: "FK_Diagnostico_Consulta_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consulta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diagnostico_Doenca_DoencaId",
                        column: x => x.DoencaId,
                        principalTable: "Doenca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tratamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    qtDiasDuracao = table.Column<int>(nullable: false),
                    Observacao = table.Column<string>(nullable: true),
                    qtHorasIntervalo = table.Column<int>(nullable: false),
                    qtDose = table.Column<int>(nullable: false),
                    ConsultaId = table.Column<int>(nullable: false),
                    RemedioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tratamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tratamento_Consulta_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consulta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tratamento_Remedio_RemedioId",
                        column: x => x.RemedioId,
                        principalTable: "Remedio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_PacienteId",
                table: "Consulta",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_UsuarioId",
                table: "Consulta",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnostico_ConsultaId",
                table: "Diagnostico",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_Remedio_MedidaId",
                table: "Remedio",
                column: "MedidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tratamento_ConsultaId",
                table: "Tratamento",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tratamento_RemedioId",
                table: "Tratamento",
                column: "RemedioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_AutorizacaoId",
                table: "Usuario",
                column: "AutorizacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diagnostico");

            migrationBuilder.DropTable(
                name: "Tratamento");

            migrationBuilder.DropTable(
                name: "Doenca");

            migrationBuilder.DropTable(
                name: "Consulta");

            migrationBuilder.DropTable(
                name: "Remedio");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Ingestao");

            migrationBuilder.DropTable(
                name: "Autorizacao");
        }
    }
}
