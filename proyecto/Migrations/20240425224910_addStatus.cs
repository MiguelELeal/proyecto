using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto.Migrations
{
    /// <inheritdoc />
    public partial class addStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "TrabajadoresRequeridos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "Trabajadores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "TipoProcedimientos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "TipoDocumentos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "Terrenos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "Siembras",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "Procedimentos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "Partida",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "LogrosConseguidos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "Logros",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "InsumosRequeridos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "Insumos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "EstadoCultivos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "DatosPartidas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "Cultivos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "status",
                table: "TrabajadoresRequeridos");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Trabajadores");

            migrationBuilder.DropColumn(
                name: "status",
                table: "TipoProcedimientos");

            migrationBuilder.DropColumn(
                name: "status",
                table: "TipoDocumentos");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Terrenos");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Siembras");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Procedimentos");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Partida");

            migrationBuilder.DropColumn(
                name: "status",
                table: "LogrosConseguidos");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Logros");

            migrationBuilder.DropColumn(
                name: "status",
                table: "InsumosRequeridos");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Insumos");

            migrationBuilder.DropColumn(
                name: "status",
                table: "EstadoCultivos");

            migrationBuilder.DropColumn(
                name: "status",
                table: "DatosPartidas");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Cultivos");
        }
    }
}
