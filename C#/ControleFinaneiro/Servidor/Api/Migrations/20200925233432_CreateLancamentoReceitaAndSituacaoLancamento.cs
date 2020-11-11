using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiCF.Migrations
{
    public partial class CreateLancamentoReceitaAndSituacaoLancamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SituacaoLancamentoReceita",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Codigo = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituacaoLancamentoReceita", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LancamentoRecitas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Codigo = table.Column<string>(nullable: true),
                    DataDespesa = table.Column<DateTime>(nullable: false),
                    Historico = table.Column<string>(nullable: true),
                    Valor = table.Column<decimal>(nullable: false),
                    SitucaoLancamentoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LancamentoRecitas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LancamentoRecitas_SituacaoLancamentoReceita_SitucaoLancamentoId",
                        column: x => x.SitucaoLancamentoId,
                        principalTable: "SituacaoLancamentoReceita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LancamentoRecitas_SitucaoLancamentoId",
                table: "LancamentoRecitas",
                column: "SitucaoLancamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LancamentoRecitas");

            migrationBuilder.DropTable(
                name: "SituacaoLancamentoReceita");
        }
    }
}
