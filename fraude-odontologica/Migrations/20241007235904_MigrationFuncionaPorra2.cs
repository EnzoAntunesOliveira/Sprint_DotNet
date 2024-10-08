using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fraude_odontologica.Migrations
{
    /// <inheritdoc />
    public partial class MigrationFuncionaPorra2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlanoSaude",
                table: "CH_PACIENTES",
                newName: "PLANO_SAUDE");

            migrationBuilder.RenameColumn(
                name: "DataNascimento",
                table: "CH_PACIENTES",
                newName: "DATA_NASCIMENTO");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "CH_DENTISTAS",
                newName: "NOME_DENTISTA");

            migrationBuilder.RenameColumn(
                name: "DataConsulta",
                table: "CH_CONSULTAS",
                newName: "DATA_CONSULTA");

            migrationBuilder.RenameColumn(
                name: "CustoConsulta",
                table: "CH_CONSULTAS",
                newName: "CUSTO_CONSULTA");

            migrationBuilder.AlterColumn<string>(
                name: "PLANO_SAUDE",
                table: "CH_PACIENTES",
                type: "VARCHAR2(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATA_NASCIMENTO",
                table: "CH_PACIENTES",
                type: "DATE",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(10)");

            migrationBuilder.AlterColumn<string>(
                name: "NOME_DENTISTA",
                table: "CH_DENTISTAS",
                type: "VARCHAR2(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATA_CONSULTA",
                table: "CH_CONSULTAS",
                type: "DATE",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CUSTO_CONSULTA",
                table: "CH_CONSULTAS",
                type: "NUMBER(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PLANO_SAUDE",
                table: "CH_PACIENTES",
                newName: "PlanoSaude");

            migrationBuilder.RenameColumn(
                name: "DATA_NASCIMENTO",
                table: "CH_PACIENTES",
                newName: "DataNascimento");

            migrationBuilder.RenameColumn(
                name: "NOME_DENTISTA",
                table: "CH_DENTISTAS",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "DATA_CONSULTA",
                table: "CH_CONSULTAS",
                newName: "DataConsulta");

            migrationBuilder.RenameColumn(
                name: "CUSTO_CONSULTA",
                table: "CH_CONSULTAS",
                newName: "CustoConsulta");

            migrationBuilder.AlterColumn<string>(
                name: "PlanoSaude",
                table: "CH_PACIENTES",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(50)");

            migrationBuilder.AlterColumn<string>(
                name: "DataNascimento",
                table: "CH_PACIENTES",
                type: "NVARCHAR2(10)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATE");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "CH_DENTISTAS",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(50)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataConsulta",
                table: "CH_CONSULTAS",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATE");

            migrationBuilder.AlterColumn<decimal>(
                name: "CustoConsulta",
                table: "CH_CONSULTAS",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(10,2)");
        }
    }
}
