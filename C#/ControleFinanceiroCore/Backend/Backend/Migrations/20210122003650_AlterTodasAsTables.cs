using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class AlterTodasAsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LancamentosDespesas_ContaDespesa_ContaId",
                table: "LancamentosDespesas");

            migrationBuilder.DropForeignKey(
                name: "FK_LancamentosDespesas_Usuarios_UsuarioId",
                table: "LancamentosDespesas");

            migrationBuilder.DropForeignKey(
                name: "FK_PagamentoDespesas_ParcelaDespesa_ParcelaId",
                table: "PagamentoDespesas");

            migrationBuilder.DropForeignKey(
                name: "FK_ParcelaDespesa_LancamentosDespesas_LancamentoId",
                table: "ParcelaDespesa");

            migrationBuilder.DropForeignKey(
                name: "FK_ParcelaReceitas_LancamentosReceitas_LancamentoId",
                table: "ParcelaReceitas");

            migrationBuilder.DropForeignKey(
                name: "FK_RecebimentoReceitas_ParcelaReceitas_ParcelaReceitaId",
                table: "RecebimentoReceitas");

            migrationBuilder.AlterColumn<int>(
                name: "ParcelaReceitaId",
                table: "RecebimentoReceitas",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LancamentoId",
                table: "ParcelaReceitas",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LancamentoId",
                table: "ParcelaDespesa",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorPago",
                table: "PagamentoDespesas",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ParcelaId",
                table: "PagamentoDespesas",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "LancamentosDespesas",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ContaId",
                table: "LancamentosDespesas",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentosDespesas_ContaDespesa_ContaId",
                table: "LancamentosDespesas",
                column: "ContaId",
                principalTable: "ContaDespesa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentosDespesas_Usuarios_UsuarioId",
                table: "LancamentosDespesas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PagamentoDespesas_ParcelaDespesa_ParcelaId",
                table: "PagamentoDespesas",
                column: "ParcelaId",
                principalTable: "ParcelaDespesa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParcelaDespesa_LancamentosDespesas_LancamentoId",
                table: "ParcelaDespesa",
                column: "LancamentoId",
                principalTable: "LancamentosDespesas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParcelaReceitas_LancamentosReceitas_LancamentoId",
                table: "ParcelaReceitas",
                column: "LancamentoId",
                principalTable: "LancamentosReceitas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecebimentoReceitas_ParcelaReceitas_ParcelaReceitaId",
                table: "RecebimentoReceitas",
                column: "ParcelaReceitaId",
                principalTable: "ParcelaReceitas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LancamentosDespesas_ContaDespesa_ContaId",
                table: "LancamentosDespesas");

            migrationBuilder.DropForeignKey(
                name: "FK_LancamentosDespesas_Usuarios_UsuarioId",
                table: "LancamentosDespesas");

            migrationBuilder.DropForeignKey(
                name: "FK_PagamentoDespesas_ParcelaDespesa_ParcelaId",
                table: "PagamentoDespesas");

            migrationBuilder.DropForeignKey(
                name: "FK_ParcelaDespesa_LancamentosDespesas_LancamentoId",
                table: "ParcelaDespesa");

            migrationBuilder.DropForeignKey(
                name: "FK_ParcelaReceitas_LancamentosReceitas_LancamentoId",
                table: "ParcelaReceitas");

            migrationBuilder.DropForeignKey(
                name: "FK_RecebimentoReceitas_ParcelaReceitas_ParcelaReceitaId",
                table: "RecebimentoReceitas");

            migrationBuilder.AlterColumn<int>(
                name: "ParcelaReceitaId",
                table: "RecebimentoReceitas",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "LancamentoId",
                table: "ParcelaReceitas",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "LancamentoId",
                table: "ParcelaDespesa",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorPago",
                table: "PagamentoDespesas",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "ParcelaId",
                table: "PagamentoDespesas",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "LancamentosDespesas",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ContaId",
                table: "LancamentosDespesas",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentosDespesas_ContaDespesa_ContaId",
                table: "LancamentosDespesas",
                column: "ContaId",
                principalTable: "ContaDespesa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentosDespesas_Usuarios_UsuarioId",
                table: "LancamentosDespesas",
                column: "UsuarioId",
                principalTable: "Usuarios",
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
                name: "FK_ParcelaDespesa_LancamentosDespesas_LancamentoId",
                table: "ParcelaDespesa",
                column: "LancamentoId",
                principalTable: "LancamentosDespesas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ParcelaReceitas_LancamentosReceitas_LancamentoId",
                table: "ParcelaReceitas",
                column: "LancamentoId",
                principalTable: "LancamentosReceitas",
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
    }
}
