using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinal.Migrations
{
    public partial class Agregando_TablaEmpleados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    EmpleadoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Direccion = table.Column<string>(type: "TEXT", nullable: true),
                    Cedula = table.Column<string>(type: "TEXT", nullable: true),
                    Telefono = table.Column<string>(type: "TEXT", nullable: true),
                    Encargado = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.EmpleadoId);
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2021, 11, 14, 14, 41, 29, 43, DateTimeKind.Local).AddTicks(916));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2021, 11, 13, 21, 56, 11, 134, DateTimeKind.Local).AddTicks(2684));
        }
    }
}
