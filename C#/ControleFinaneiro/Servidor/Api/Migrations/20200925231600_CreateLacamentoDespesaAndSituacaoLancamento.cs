using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiCF.Migrations
{
    public partial class CreateLacamentoDespesaAndSituacaoLancamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SituacaoLancamentoDespesa",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Codigo = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituacaoLancamentoDespesa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LancamentoDespesas",
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
                    table.PrimaryKey("PK_LancamentoDespesas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LancamentoDespesas_SituacaoLancamentoDespesa_SitucaoLancamentoId",
                        column: x => x.SitucaoLancamentoId,
                        principalTable: "SituacaoLancamentoDespesa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LancamentoDespesas_SitucaoLancamentoId",
                table: "LancamentoDespesas",
                column: "SitucaoLancamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LancamentoDespesas");

            migrationBuilder.DropTable(
                name: "SituacaoLancamentoDespesa");
        }
    }
}
