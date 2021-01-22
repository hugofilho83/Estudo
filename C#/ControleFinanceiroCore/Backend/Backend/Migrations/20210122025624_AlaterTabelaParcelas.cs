using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class AlaterTabelaParcelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LancamentosDespesas_SituacaoLancamentoDesposa_SitucaoLancam~",
                table: "LancamentosDespesas");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorPago",
                table: "ParcelaDespesa",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPagto",
                table: "ParcelaDespesa",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<int>(
                name: "SitucaoLancamentoId",
                table: "LancamentosDespesas",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentosDespesas_SituacaoLancamentoDesposa_SitucaoLancam~",
                table: "LancamentosDespesas",
                column: "SitucaoLancamentoId",
                principalTable: "SituacaoLancamentoDesposa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LancamentosDespesas_SituacaoLancamentoDesposa_SitucaoLancam~",
                table: "LancamentosDespesas");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorPago",
                table: "ParcelaDespesa",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPagto",
                table: "ParcelaDespesa",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SitucaoLancamentoId",
                table: "LancamentosDespesas",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentosDespesas_SituacaoLancamentoDesposa_SitucaoLancam~",
                table: "LancamentosDespesas",
                column: "SitucaoLancamentoId",
                principalTable: "SituacaoLancamentoDesposa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
