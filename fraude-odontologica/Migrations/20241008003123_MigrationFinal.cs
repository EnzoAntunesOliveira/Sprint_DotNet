using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fraude_odontologica.Migrations
{
    /// <inheritdoc />
    public partial class MigrationFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "CH_PACIENTES",
                newName: "TELEFONE");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "CH_PACIENTES",
                newName: "NOME");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "CH_PACIENTES",
                newName: "EMAIL");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CH_PACIENTES",
                newName: "ID_PACIENTE");

            migrationBuilder.RenameColumn(
                name: "Especialidade",
                table: "CH_DENTISTAS",
                newName: "ESPECIALIDADE");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CH_DENTISTAS",
                newName: "ID_DENTISTA");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CH_CONSULTAS",
                newName: "ID_CONSULTA");

            migrationBuilder.AlterColumn<string>(
                name: "TELEFONE",
                table: "CH_PACIENTES",
                type: "VARCHAR2(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "NOME",
                table: "CH_PACIENTES",
                type: "VARCHAR2(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL",
                table: "CH_PACIENTES",
                type: "VARCHAR2(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "ESPECIALIDADE",
                table: "CH_DENTISTAS",
                type: "VARCHAR2(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TELEFONE",
                table: "CH_PACIENTES",
                newName: "Telefone");

            migrationBuilder.RenameColumn(
                name: "NOME",
                table: "CH_PACIENTES",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "EMAIL",
                table: "CH_PACIENTES",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "ID_PACIENTE",
                table: "CH_PACIENTES",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ESPECIALIDADE",
                table: "CH_DENTISTAS",
                newName: "Especialidade");

            migrationBuilder.RenameColumn(
                name: "ID_DENTISTA",
                table: "CH_DENTISTAS",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID_CONSULTA",
                table: "CH_CONSULTAS",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "CH_PACIENTES",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "CH_PACIENTES",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(30)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "CH_PACIENTES",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Especialidade",
                table: "CH_DENTISTAS",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(30)");
        }
    }
}
