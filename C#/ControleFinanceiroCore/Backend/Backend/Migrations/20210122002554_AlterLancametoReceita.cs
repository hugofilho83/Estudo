using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class AlterLancametoReceita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LancamentosReceitas_ContaReceita_ContaId",
                table: "LancamentosReceitas");

            migrationBuilder.DropForeignKey(
                name: "FK_LancamentosReceitas_SituacaoLancamentoReceita_SitucaoLancam~",
                table: "LancamentosReceitas");

            migrationBuilder.DropForeignKey(
                name: "FK_LancamentosReceitas_Usuarios_UsuarioId",
                table: "LancamentosReceitas");

            migrationBuilder.RenameColumn(
                name: "DataDespesa",
                table: "LancamentosReceitas",
                newName: "DataReceita");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "LancamentosReceitas",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SitucaoLancamentoId",
                table: "LancamentosReceitas",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ContaId",
                table: "LancamentosReceitas",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentosReceitas_ContaReceita_ContaId",
                table: "LancamentosReceitas",
                column: "ContaId",
                principalTable: "ContaReceita",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentosReceitas_SituacaoLancamentoReceita_SitucaoLancam~",
                table: "LancamentosReceitas",
                column: "SitucaoLancamentoId",
                principalTable: "SituacaoLancamentoReceita",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentosReceitas_Usuarios_UsuarioId",
                table: "LancamentosReceitas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LancamentosReceitas_ContaReceita_ContaId",
                table: "LancamentosReceitas");

            migrationBuilder.DropForeignKey(
                name: "FK_LancamentosReceitas_SituacaoLancamentoReceita_SitucaoLancam~",
                table: "LancamentosReceitas");

            migrationBuilder.DropForeignKey(
                name: "FK_LancamentosReceitas_Usuarios_UsuarioId",
                table: "LancamentosReceitas");

            migrationBuilder.RenameColumn(
                name: "DataReceita",
                table: "LancamentosReceitas",
                newName: "DataDespesa");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "LancamentosReceitas",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "SitucaoLancamentoId",
                table: "LancamentosReceitas",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ContaId",
                table: "LancamentosReceitas",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentosReceitas_ContaReceita_ContaId",
                table: "LancamentosReceitas",
                column: "ContaId",
                principalTable: "ContaReceita",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentosReceitas_SituacaoLancamentoReceita_SitucaoLancam~",
                table: "LancamentosReceitas",
                column: "SitucaoLancamentoId",
                principalTable: "SituacaoLancamentoReceita",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentosReceitas_Usuarios_UsuarioId",
                table: "LancamentosReceitas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
