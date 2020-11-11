using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiCF.Migrations
{
    public partial class AlterLancamentoReceitaAndDespesaAddedParcelaAndTotalParcela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Parcela",
                table: "LancamentoRecitas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalParcela",
                table: "LancamentoRecitas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Parcela",
                table: "LancamentoDespesas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalParcela",
                table: "LancamentoDespesas",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Parcela",
                table: "LancamentoRecitas");

            migrationBuilder.DropColumn(
                name: "TotalParcela",
                table: "LancamentoRecitas");

            migrationBuilder.DropColumn(
                name: "Parcela",
                table: "LancamentoDespesas");

            migrationBuilder.DropColumn(
                name: "TotalParcela",
                table: "LancamentoDespesas");
        }
    }
}
