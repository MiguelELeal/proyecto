using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto.Migrations
{
    /// <inheritdoc />
    public partial class AddRelaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partida_Usuarios_UsuarioIDUsuario",
                table: "Partida");

            migrationBuilder.DropIndex(
                name: "IX_Partida_UsuarioIDUsuario",
                table: "Partida");

            migrationBuilder.DropColumn(
                name: "UsuarioIDUsuario",
                table: "Partida");

            migrationBuilder.RenameColumn(
                name: "IDUsuario",
                table: "Partida",
                newName: "IDUsuarioFK");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_IDUsuarioFK",
                table: "Partida",
                column: "IDUsuarioFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Partida_Usuarios_IDUsuarioFK",
                table: "Partida",
                column: "IDUsuarioFK",
                principalTable: "Usuarios",
                principalColumn: "IDUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partida_Usuarios_IDUsuarioFK",
                table: "Partida");

            migrationBuilder.DropIndex(
                name: "IX_Partida_IDUsuarioFK",
                table: "Partida");

            migrationBuilder.RenameColumn(
                name: "IDUsuarioFK",
                table: "Partida",
                newName: "IDUsuario");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioIDUsuario",
                table: "Partida",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Partida_UsuarioIDUsuario",
                table: "Partida",
                column: "UsuarioIDUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Partida_Usuarios_UsuarioIDUsuario",
                table: "Partida",
                column: "UsuarioIDUsuario",
                principalTable: "Usuarios",
                principalColumn: "IDUsuario");
        }
    }
}
