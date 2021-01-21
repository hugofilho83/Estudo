using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Backend.Migrations
{
    public partial class CreateRecebimentoPagamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PagamentoDespesas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LancamentoId = table.Column<int>(type: "integer", nullable: true),
                    Parcela = table.Column<int>(type: "integer", nullable: false),
                    ValorPago = table.Column<decimal>(type: "numeric", nullable: false),
                    DataPagto = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Historico = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagamentoDespesas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PagamentoDespesas_LancamentosDespesas_LancamentoId",
                        column: x => x.LancamentoId,
                        principalTable: "LancamentosDespesas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecebimentoReceitas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LancamentoId = table.Column<int>(type: "integer", nullable: true),
                    Parcela = table.Column<int>(type: "integer", nullable: false),
                    ValorPago = table.Column<decimal>(type: "numeric", nullable: false),
                    DataPagto = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Historico = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecebimentoReceitas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecebimentoReceitas_LancamentosReceitas_LancamentoId",
                        column: x => x.LancamentoId,
                        principalTable: "LancamentosReceitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PagamentoDespesas_LancamentoId",
                table: "PagamentoDespesas",
                column: "LancamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_RecebimentoReceitas_LancamentoId",
                table: "RecebimentoReceitas",
                column: "LancamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PagamentoDespesas");

            migrationBuilder.DropTable(
                name: "RecebimentoReceitas");
        }
    }
}
