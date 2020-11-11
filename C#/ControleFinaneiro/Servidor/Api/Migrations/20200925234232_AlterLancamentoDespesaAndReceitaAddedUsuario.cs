using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiCF.Migrations
{
    public partial class AlterLancamentoDespesaAndReceitaAddedUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "LancamentoRecitas",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "LancamentoDespesas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LancamentoRecitas_UsuarioId",
                table: "LancamentoRecitas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_LancamentoDespesas_UsuarioId",
                table: "LancamentoDespesas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentoDespesas_Usuarios_UsuarioId",
                table: "LancamentoDespesas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentoRecitas_Usuarios_UsuarioId",
                table: "LancamentoRecitas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LancamentoDespesas_Usuarios_UsuarioId",
                table: "LancamentoDespesas");

            migrationBuilder.DropForeignKey(
                name: "FK_LancamentoRecitas_Usuarios_UsuarioId",
                table: "LancamentoRecitas");

            migrationBuilder.DropIndex(
                name: "IX_LancamentoRecitas_UsuarioId",
                table: "LancamentoRecitas");

            migrationBuilder.DropIndex(
                name: "IX_LancamentoDespesas_UsuarioId",
                table: "LancamentoDespesas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "LancamentoRecitas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "LancamentoDespesas");
        }
    }
}
