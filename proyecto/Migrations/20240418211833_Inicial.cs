using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadoCultivos",
                columns: table => new
                {
                    IDEstado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEstado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCultivos", x => x.IDEstado);
                });

            migrationBuilder.CreateTable(
                name: "Insumos",
                columns: table => new
                {
                    IDInsumo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreInsumo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insumos", x => x.IDInsumo);
                });

            migrationBuilder.CreateTable(
                name: "Logros",
                columns: table => new
                {
                    IDLogro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreLogro = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logros", x => x.IDLogro);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoRol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "Terrenos",
                columns: table => new
                {
                    IDTerreno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terrenos", x => x.IDTerreno);
                });

            migrationBuilder.CreateTable(
                name: "TipoDocumentos",
                columns: table => new
                {
                    IDTipoDoc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumentos", x => x.IDTipoDoc);
                });

            migrationBuilder.CreateTable(
                name: "TipoProcedimientos",
                columns: table => new
                {
                    IDTipoPro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProcedimientos", x => x.IDTipoPro);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IDUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdRolFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IDUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_IdRolFK",
                        column: x => x.IdRolFK,
                        principalTable: "Roles",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Siembras",
                columns: table => new
                {
                    IDSiembra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaSiembra = table.Column<DateOnly>(type: "date", nullable: false),
                    AreaTotalS = table.Column<float>(type: "real", nullable: false),
                    IDTerrenoFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siembras", x => x.IDSiembra);
                    table.ForeignKey(
                        name: "FK_Siembras_Terrenos_IDTerrenoFK",
                        column: x => x.IDTerrenoFK,
                        principalTable: "Terrenos",
                        principalColumn: "IDTerreno",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trabajadores",
                columns: table => new
                {
                    IDTrabajador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumDoc = table.Column<int>(type: "int", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDRolFK = table.Column<int>(type: "int", nullable: false),
                    IDTipoDocFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabajadores", x => x.IDTrabajador);
                    table.ForeignKey(
                        name: "FK_Trabajadores_Roles_IDRolFK",
                        column: x => x.IDRolFK,
                        principalTable: "Roles",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trabajadores_TipoDocumentos_IDTipoDocFK",
                        column: x => x.IDTipoDocFK,
                        principalTable: "TipoDocumentos",
                        principalColumn: "IDTipoDoc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Partida",
                columns: table => new
                {
                    IDPartida = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUsuario = table.Column<int>(type: "int", nullable: false),
                    UsuarioIDUsuario = table.Column<int>(type: "int", nullable: true),
                    FechaInicio = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partida", x => x.IDPartida);
                    table.ForeignKey(
                        name: "FK_Partida_Usuarios_UsuarioIDUsuario",
                        column: x => x.UsuarioIDUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IDUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Cultivos",
                columns: table => new
                {
                    IDCultivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSiembraFK = table.Column<int>(type: "int", nullable: false),
                    FechaCosechaE = table.Column<DateOnly>(type: "date", nullable: false),
                    IdEstadoFK = table.Column<int>(type: "int", nullable: false),
                    FechaModificacion = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cultivos", x => x.IDCultivo);
                    table.ForeignKey(
                        name: "FK_Cultivos_EstadoCultivos_IdEstadoFK",
                        column: x => x.IdEstadoFK,
                        principalTable: "EstadoCultivos",
                        principalColumn: "IDEstado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cultivos_Siembras_IdSiembraFK",
                        column: x => x.IdSiembraFK,
                        principalTable: "Siembras",
                        principalColumn: "IDSiembra",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogrosConseguidos",
                columns: table => new
                {
                    IDLogCon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPartidaFK = table.Column<int>(type: "int", nullable: false),
                    IDLogroFK = table.Column<int>(type: "int", nullable: false),
                    FechaLogro = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogrosConseguidos", x => x.IDLogCon);
                    table.ForeignKey(
                        name: "FK_LogrosConseguidos_Logros_IDLogroFK",
                        column: x => x.IDLogroFK,
                        principalTable: "Logros",
                        principalColumn: "IDLogro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LogrosConseguidos_Partida_IDPartidaFK",
                        column: x => x.IDPartidaFK,
                        principalTable: "Partida",
                        principalColumn: "IDPartida",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Procedimentos",
                columns: table => new
                {
                    IDProcedimiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCultivoFK = table.Column<int>(type: "int", nullable: false),
                    IDTipoProcedimientoFK = table.Column<int>(type: "int", nullable: false),
                    FechaProcedimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedimentos", x => x.IDProcedimiento);
                    table.ForeignKey(
                        name: "FK_Procedimentos_Cultivos_IDCultivoFK",
                        column: x => x.IDCultivoFK,
                        principalTable: "Cultivos",
                        principalColumn: "IDCultivo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Procedimentos_TipoProcedimientos_IDTipoProcedimientoFK",
                        column: x => x.IDTipoProcedimientoFK,
                        principalTable: "TipoProcedimientos",
                        principalColumn: "IDTipoPro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InsumosRequeridos",
                columns: table => new
                {
                    IDInRe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDInsumoFK = table.Column<int>(type: "int", nullable: false),
                    IDProcedimientoFK = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsumosRequeridos", x => x.IDInRe);
                    table.ForeignKey(
                        name: "FK_InsumosRequeridos_Insumos_IDInsumoFK",
                        column: x => x.IDInsumoFK,
                        principalTable: "Insumos",
                        principalColumn: "IDInsumo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsumosRequeridos_Procedimentos_IDProcedimientoFK",
                        column: x => x.IDProcedimientoFK,
                        principalTable: "Procedimentos",
                        principalColumn: "IDProcedimiento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrabajadoresRequeridos",
                columns: table => new
                {
                    IDTraRe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDTrabjadorFK = table.Column<int>(type: "int", nullable: false),
                    IDProcedimientoFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrabajadoresRequeridos", x => x.IDTraRe);
                    table.ForeignKey(
                        name: "FK_TrabajadoresRequeridos_Procedimentos_IDProcedimientoFK",
                        column: x => x.IDProcedimientoFK,
                        principalTable: "Procedimentos",
                        principalColumn: "IDProcedimiento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrabajadoresRequeridos_Trabajadores_IDTrabjadorFK",
                        column: x => x.IDTrabjadorFK,
                        principalTable: "Trabajadores",
                        principalColumn: "IDTrabajador",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cultivos_IdEstadoFK",
                table: "Cultivos",
                column: "IdEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Cultivos_IdSiembraFK",
                table: "Cultivos",
                column: "IdSiembraFK");

            migrationBuilder.CreateIndex(
                name: "IX_InsumosRequeridos_IDInsumoFK",
                table: "InsumosRequeridos",
                column: "IDInsumoFK");

            migrationBuilder.CreateIndex(
                name: "IX_InsumosRequeridos_IDProcedimientoFK",
                table: "InsumosRequeridos",
                column: "IDProcedimientoFK");

            migrationBuilder.CreateIndex(
                name: "IX_LogrosConseguidos_IDLogroFK",
                table: "LogrosConseguidos",
                column: "IDLogroFK");

            migrationBuilder.CreateIndex(
                name: "IX_LogrosConseguidos_IDPartidaFK",
                table: "LogrosConseguidos",
                column: "IDPartidaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_UsuarioIDUsuario",
                table: "Partida",
                column: "UsuarioIDUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Procedimentos_IDCultivoFK",
                table: "Procedimentos",
                column: "IDCultivoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Procedimentos_IDTipoProcedimientoFK",
                table: "Procedimentos",
                column: "IDTipoProcedimientoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Siembras_IDTerrenoFK",
                table: "Siembras",
                column: "IDTerrenoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Trabajadores_IDRolFK",
                table: "Trabajadores",
                column: "IDRolFK");

            migrationBuilder.CreateIndex(
                name: "IX_Trabajadores_IDTipoDocFK",
                table: "Trabajadores",
                column: "IDTipoDocFK");

            migrationBuilder.CreateIndex(
                name: "IX_TrabajadoresRequeridos_IDProcedimientoFK",
                table: "TrabajadoresRequeridos",
                column: "IDProcedimientoFK");

            migrationBuilder.CreateIndex(
                name: "IX_TrabajadoresRequeridos_IDTrabjadorFK",
                table: "TrabajadoresRequeridos",
                column: "IDTrabjadorFK");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdRolFK",
                table: "Usuarios",
                column: "IdRolFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsumosRequeridos");

            migrationBuilder.DropTable(
                name: "LogrosConseguidos");

            migrationBuilder.DropTable(
                name: "TrabajadoresRequeridos");

            migrationBuilder.DropTable(
                name: "Insumos");

            migrationBuilder.DropTable(
                name: "Logros");

            migrationBuilder.DropTable(
                name: "Partida");

            migrationBuilder.DropTable(
                name: "Procedimentos");

            migrationBuilder.DropTable(
                name: "Trabajadores");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cultivos");

            migrationBuilder.DropTable(
                name: "TipoProcedimientos");

            migrationBuilder.DropTable(
                name: "TipoDocumentos");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "EstadoCultivos");

            migrationBuilder.DropTable(
                name: "Siembras");

            migrationBuilder.DropTable(
                name: "Terrenos");
        }
    }
}
