using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto.Migrations
{
    /// <inheritdoc />
    public partial class addDatosPartidas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DatosPartidas",
                columns: table => new
                {
                    IdDatosJugador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPartidaFk = table.Column<int>(type: "int", nullable: false),
                    IdProcedimientoFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatosPartidas", x => x.IdDatosJugador);
                    table.ForeignKey(
                        name: "FK_DatosPartidas_Partida_IdPartidaFk",
                        column: x => x.IdPartidaFk,
                        principalTable: "Partida",
                        principalColumn: "IDPartida",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DatosPartidas_Procedimentos_IdProcedimientoFk",
                        column: x => x.IdProcedimientoFk,
                        principalTable: "Procedimentos",
                        principalColumn: "IDProcedimiento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DatosPartidas_IdPartidaFk",
                table: "DatosPartidas",
                column: "IdPartidaFk");

            migrationBuilder.CreateIndex(
                name: "IX_DatosPartidas_IdProcedimientoFk",
                table: "DatosPartidas",
                column: "IdProcedimientoFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DatosPartidas");
        }
    }
}
