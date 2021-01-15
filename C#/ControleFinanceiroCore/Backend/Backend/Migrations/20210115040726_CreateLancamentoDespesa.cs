using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Backend.Migrations
{
    public partial class CreateLancamentoDespesa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LancamentosDespesas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<int>(type: "integer", nullable: true),
                    ContaId = table.Column<int>(type: "integer", nullable: true),
                    DataDespesa = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Historico = table.Column<string>(type: "text", nullable: true),
                    Parcela = table.Column<int>(type: "integer", nullable: false),
                    TotalParcela = table.Column<int>(type: "integer", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false),
                    SitucaoLancamentoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LancamentosDespesas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LancamentosDespesas_ContaDespesa_ContaId",
                        column: x => x.ContaId,
                        principalTable: "ContaDespesa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LancamentosDespesas_SituacaoLancamentoDesposa_SitucaoLancam~",
                        column: x => x.SitucaoLancamentoId,
                        principalTable: "SituacaoLancamentoDesposa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LancamentosDespesas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LancamentosDespesas_ContaId",
                table: "LancamentosDespesas",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_LancamentosDespesas_SitucaoLancamentoId",
                table: "LancamentosDespesas",
                column: "SitucaoLancamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_LancamentosDespesas_UsuarioId",
                table: "LancamentosDespesas",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LancamentosDespesas");
        }
    }
}
