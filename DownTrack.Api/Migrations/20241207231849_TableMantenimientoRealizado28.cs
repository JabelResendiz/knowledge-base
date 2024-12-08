using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DownTrack.Api.Migrations
{
    /// <inheritdoc />
    public partial class TableMantenimientoRealizado28 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MantenimientosRealizados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TecnicoId = table.Column<int>(type: "int", nullable: true),
                    MantenimientoId = table.Column<int>(type: "int", nullable: true),
                    EquipoId = table.Column<int>(type: "int", nullable: true),
                    FechaRealizacion = table.Column<DateTime>(type: "date", nullable: false),
                    CostoMant = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MantenimientosRealizados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MantenimientosRealizados_Equipos_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_MantenimientosRealizados_Mantenimientos_MantenimientoId",
                        column: x => x.MantenimientoId,
                        principalTable: "Mantenimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_MantenimientosRealizados_Tecnicos_TecnicoId",
                        column: x => x.TecnicoId,
                        principalTable: "Tecnicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_MantenimientosRealizados_EquipoId",
                table: "MantenimientosRealizados",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_MantenimientosRealizados_MantenimientoId",
                table: "MantenimientosRealizados",
                column: "MantenimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_MantenimientosRealizados_TecnicoId",
                table: "MantenimientosRealizados",
                column: "TecnicoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MantenimientosRealizados");
        }
    }
}
