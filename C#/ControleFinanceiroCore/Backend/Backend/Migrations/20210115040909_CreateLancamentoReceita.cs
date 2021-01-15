using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Backend.Migrations
{
    public partial class CreateLancamentoReceita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LancamentosReceitas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<int>(type: "integer", nullable: true),
                    contaId = table.Column<int>(type: "integer", nullable: true),
                    DataDespesa = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Historico = table.Column<string>(type: "text", nullable: true),
                    Parcela = table.Column<int>(type: "integer", nullable: false),
                    TotalParcela = table.Column<int>(type: "integer", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false),
                    SitucaoLancamentoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LancamentosReceitas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LancamentosReceitas_ContaReceita_contaId",
                        column: x => x.contaId,
                        principalTable: "ContaReceita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LancamentosReceitas_SituacaoLancamentoReceita_SitucaoLancam~",
                        column: x => x.SitucaoLancamentoId,
                        principalTable: "SituacaoLancamentoReceita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LancamentosReceitas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LancamentosReceitas_contaId",
                table: "LancamentosReceitas",
                column: "contaId");

            migrationBuilder.CreateIndex(
                name: "IX_LancamentosReceitas_SitucaoLancamentoId",
                table: "LancamentosReceitas",
                column: "SitucaoLancamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_LancamentosReceitas_UsuarioId",
                table: "LancamentosReceitas",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LancamentosReceitas");
        }
    }
}
