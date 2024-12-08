using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DownTrack.Api.Migrations
{
    /// <inheritdoc />
    public partial class CreateEvaluacionAndRelationships3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluaciones_Tecnicos_TecnicoId",
                table: "Evaluaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluaciones_Usuarios_JefeSeccId",
                table: "Evaluaciones");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaEvaluacion",
                table: "Evaluaciones",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluaciones_Tecnicos_TecnicoId",
                table: "Evaluaciones",
                column: "TecnicoId",
                principalTable: "Tecnicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluaciones_Usuarios_JefeSeccId",
                table: "Evaluaciones",
                column: "JefeSeccId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluaciones_Tecnicos_TecnicoId",
                table: "Evaluaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluaciones_Usuarios_JefeSeccId",
                table: "Evaluaciones");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaEvaluacion",
                table: "Evaluaciones",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluaciones_Tecnicos_TecnicoId",
                table: "Evaluaciones",
                column: "TecnicoId",
                principalTable: "Tecnicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluaciones_Usuarios_JefeSeccId",
                table: "Evaluaciones",
                column: "JefeSeccId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
