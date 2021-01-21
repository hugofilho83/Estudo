using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Backend.Migrations
{
    public partial class CreatreParcelaDespesaReceita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LancamentosReceitas_ContaReceita_contaId",
                table: "LancamentosReceitas");

            migrationBuilder.DropForeignKey(
                name: "FK_PagamentoDespesas_LancamentosDespesas_LancamentoId",
                table: "PagamentoDespesas");

            migrationBuilder.DropForeignKey(
                name: "FK_RecebimentoReceitas_LancamentosReceitas_LancamentoId",
                table: "RecebimentoReceitas");

            migrationBuilder.DropColumn(
                name: "Parcela",
                table: "RecebimentoReceitas");

            migrationBuilder.DropColumn(
                name: "Parcela",
                table: "PagamentoDespesas");

            migrationBuilder.RenameColumn(
                name: "LancamentoId",
                table: "RecebimentoReceitas",
                newName: "ParcelaReceitaId");

            migrationBuilder.RenameColumn(
                name: "DataPagto",
                table: "RecebimentoReceitas",
                newName: "DataReceb");

            migrationBuilder.RenameIndex(
                name: "IX_RecebimentoReceitas_LancamentoId",
                table: "RecebimentoReceitas",
                newName: "IX_RecebimentoReceitas_ParcelaReceitaId");

            migrationBuilder.RenameColumn(
                name: "LancamentoId",
                table: "PagamentoDespesas",
                newName: "ParcelaId");

            migrationBuilder.RenameIndex(
                name: "IX_PagamentoDespesas_LancamentoId",
                table: "PagamentoDespesas",
                newName: "IX_PagamentoDespesas_ParcelaId");

            migrationBuilder.RenameColumn(
                name: "contaId",
                table: "LancamentosReceitas",
                newName: "ContaId");

            migrationBuilder.RenameIndex(
                name: "IX_LancamentosReceitas_contaId",
                table: "LancamentosReceitas",
                newName: "IX_LancamentosReceitas_ContaId");


            migrationBuilder.AlterColumn<decimal>(
                name: "ValorPago",
                table: "PagamentoDespesas",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPagto",
                table: "PagamentoDespesas",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<int>(
                name: "ContaId",
                table: "PagamentoDespesas",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ParcelaDespesa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LancamentoId = table.Column<int>(type: "integer", nullable: true),
                    Parcela = table.Column<int>(type: "integer", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false),
                    ValorPago = table.Column<decimal>(type: "numeric", nullable: false),
                    DataPagto = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Historico = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelaDespesa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParcelaDespesa_LancamentosDespesas_LancamentoId",
                        column: x => x.LancamentoId,
                        principalTable: "LancamentosDespesas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParcelaReceitas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LancamentoId = table.Column<int>(type: "integer", nullable: true),
                    Parcela = table.Column<int>(type: "integer", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false),
                    ValorRecebido = table.Column<decimal>(type: "numeric", nullable: true),
                    DataRecebido = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Historico = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelaReceitas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParcelaReceitas_LancamentosReceitas_LancamentoId",
                        column: x => x.LancamentoId,
                        principalTable: "LancamentosReceitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PagamentoDespesas_ContaId",
                table: "PagamentoDespesas",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelaDespesa_LancamentoId",
                table: "ParcelaDespesa",
                column: "LancamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelaReceitas_LancamentoId",
                table: "ParcelaReceitas",
                column: "LancamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentosReceitas_ContaReceita_ContaId",
                table: "LancamentosReceitas",
                column: "ContaId",
                principalTable: "ContaReceita",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PagamentoDespesas_ContaReceita_ContaId",
                table: "PagamentoDespesas",
                column: "ContaId",
                principalTable: "ContaReceita",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PagamentoDespesas_ParcelaDespesa_ParcelaId",
                table: "PagamentoDespesas",
                column: "ParcelaId",
                principalTable: "ParcelaDespesa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecebimentoReceitas_ParcelaReceitas_ParcelaReceitaId",
                table: "RecebimentoReceitas",
                column: "ParcelaReceitaId",
                principalTable: "ParcelaReceitas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LancamentosReceitas_ContaReceita_ContaId",
                table: "LancamentosReceitas");

            migrationBuilder.DropForeignKey(
                name: "FK_PagamentoDespesas_ContaReceita_ContaId",
                table: "PagamentoDespesas");

            migrationBuilder.DropForeignKey(
                name: "FK_PagamentoDespesas_ParcelaDespesa_ParcelaId",
                table: "PagamentoDespesas");

            migrationBuilder.DropForeignKey(
                name: "FK_RecebimentoReceitas_ParcelaReceitas_ParcelaReceitaId",
                table: "RecebimentoReceitas");

            migrationBuilder.DropTable(
                name: "ParcelaDespesa");

            migrationBuilder.DropTable(
                name: "ParcelaReceitas");

            migrationBuilder.DropIndex(
                name: "IX_PagamentoDespesas_ContaId",
                table: "PagamentoDespesas");

            migrationBuilder.DropColumn(
                name: "ContaId",
                table: "PagamentoDespesas");

            migrationBuilder.RenameColumn(
                name: "ParcelaReceitaId",
                table: "RecebimentoReceitas",
                newName: "LancamentoId");

            migrationBuilder.RenameColumn(
                name: "DataReceb",
                table: "RecebimentoReceitas",
                newName: "DataPagto");

            migrationBuilder.RenameIndex(
                name: "IX_RecebimentoReceitas_ParcelaReceitaId",
                table: "RecebimentoReceitas",
                newName: "IX_RecebimentoReceitas_LancamentoId");

            migrationBuilder.RenameColumn(
                name: "ParcelaId",
                table: "PagamentoDespesas",
                newName: "LancamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_PagamentoDespesas_ParcelaId",
                table: "PagamentoDespesas",
                newName: "IX_PagamentoDespesas_LancamentoId");

            migrationBuilder.RenameColumn(
                name: "ContaId",
                table: "LancamentosReceitas",
                newName: "contaId");

            migrationBuilder.RenameIndex(
                name: "IX_LancamentosReceitas_ContaId",
                table: "LancamentosReceitas",
                newName: "IX_LancamentosReceitas_contaId");

      
            migrationBuilder.AddColumn<int>(
                name: "Parcela",
                table: "RecebimentoReceitas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorPago",
                table: "PagamentoDespesas",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPagto",
                table: "PagamentoDespesas",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Parcela",
                table: "PagamentoDespesas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentosReceitas_ContaReceita_contaId",
                table: "LancamentosReceitas",
                column: "contaId",
                principalTable: "ContaReceita",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PagamentoDespesas_LancamentosDespesas_LancamentoId",
                table: "PagamentoDespesas",
                column: "LancamentoId",
                principalTable: "LancamentosDespesas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecebimentoReceitas_LancamentosReceitas_LancamentoId",
                table: "RecebimentoReceitas",
                column: "LancamentoId",
                principalTable: "LancamentosReceitas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
