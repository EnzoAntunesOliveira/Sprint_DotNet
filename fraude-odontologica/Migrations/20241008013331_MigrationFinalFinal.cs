using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fraude_odontologica.Migrations
{
    /// <inheritdoc />
    public partial class MigrationFinalFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CH_CONSULTAS_CH_DENTISTAS_DentistaId",
                table: "CH_CONSULTAS");

            migrationBuilder.DropForeignKey(
                name: "FK_CH_CONSULTAS_CH_PACIENTES_PacienteId",
                table: "CH_CONSULTAS");

            migrationBuilder.RenameColumn(
                name: "TipoTratamento",
                table: "CH_CONSULTAS",
                newName: "TIPO_TRATAMENTO");

            migrationBuilder.RenameColumn(
                name: "PacienteId",
                table: "CH_CONSULTAS",
                newName: "ID_PACIENTE");

            migrationBuilder.RenameColumn(
                name: "DentistaId",
                table: "CH_CONSULTAS",
                newName: "ID_DENTISTA");

            migrationBuilder.RenameIndex(
                name: "IX_CH_CONSULTAS_PacienteId",
                table: "CH_CONSULTAS",
                newName: "IX_CH_CONSULTAS_ID_PACIENTE");

            migrationBuilder.RenameIndex(
                name: "IX_CH_CONSULTAS_DentistaId",
                table: "CH_CONSULTAS",
                newName: "IX_CH_CONSULTAS_ID_DENTISTA");

            migrationBuilder.AlterColumn<string>(
                name: "TIPO_TRATAMENTO",
                table: "CH_CONSULTAS",
                type: "VARCHAR2(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AddForeignKey(
                name: "FK_CH_CONSULTAS_CH_DENTISTAS_ID_DENTISTA",
                table: "CH_CONSULTAS",
                column: "ID_DENTISTA",
                principalTable: "CH_DENTISTAS",
                principalColumn: "ID_DENTISTA",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CH_CONSULTAS_CH_PACIENTES_ID_PACIENTE",
                table: "CH_CONSULTAS",
                column: "ID_PACIENTE",
                principalTable: "CH_PACIENTES",
                principalColumn: "ID_PACIENTE",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CH_CONSULTAS_CH_DENTISTAS_ID_DENTISTA",
                table: "CH_CONSULTAS");

            migrationBuilder.DropForeignKey(
                name: "FK_CH_CONSULTAS_CH_PACIENTES_ID_PACIENTE",
                table: "CH_CONSULTAS");

            migrationBuilder.RenameColumn(
                name: "TIPO_TRATAMENTO",
                table: "CH_CONSULTAS",
                newName: "TipoTratamento");

            migrationBuilder.RenameColumn(
                name: "ID_PACIENTE",
                table: "CH_CONSULTAS",
                newName: "PacienteId");

            migrationBuilder.RenameColumn(
                name: "ID_DENTISTA",
                table: "CH_CONSULTAS",
                newName: "DentistaId");

            migrationBuilder.RenameIndex(
                name: "IX_CH_CONSULTAS_ID_PACIENTE",
                table: "CH_CONSULTAS",
                newName: "IX_CH_CONSULTAS_PacienteId");

            migrationBuilder.RenameIndex(
                name: "IX_CH_CONSULTAS_ID_DENTISTA",
                table: "CH_CONSULTAS",
                newName: "IX_CH_CONSULTAS_DentistaId");

            migrationBuilder.AlterColumn<string>(
                name: "TipoTratamento",
                table: "CH_CONSULTAS",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2(50)");

            migrationBuilder.AddForeignKey(
                name: "FK_CH_CONSULTAS_CH_DENTISTAS_DentistaId",
                table: "CH_CONSULTAS",
                column: "DentistaId",
                principalTable: "CH_DENTISTAS",
                principalColumn: "ID_DENTISTA",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CH_CONSULTAS_CH_PACIENTES_PacienteId",
                table: "CH_CONSULTAS",
                column: "PacienteId",
                principalTable: "CH_PACIENTES",
                principalColumn: "ID_PACIENTE",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
