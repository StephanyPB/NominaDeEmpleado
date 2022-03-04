using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tarea6Empresa.Migrations
{
    public partial class Migraciion_Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    DepartamentoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.DepartamentoId);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Telefono = table.Column<string>(type: "TEXT", nullable: false),
                    Salario = table.Column<double>(type: "REAL", nullable: false),
                    fechaIngreso = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Edad = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nomina",
                columns: table => new
                {
                    NominaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmpleadoId = table.Column<int>(type: "INTEGER", nullable: false),
                    SalarioMensual = table.Column<double>(type: "REAL", nullable: false),
                    HorasExtra = table.Column<double>(type: "REAL", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SFS = table.Column<double>(type: "REAL", nullable: false),
                    AFP = table.Column<double>(type: "REAL", nullable: false),
                    ISR = table.Column<double>(type: "REAL", nullable: false),
                    SueldoTotal = table.Column<double>(type: "REAL", nullable: false),
                    TotalDecuentos = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nomina", x => x.NominaId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolId);
                });

            migrationBuilder.InsertData(
                table: "Departamento",
                columns: new[] { "DepartamentoId", "Descripcion" },
                values: new object[] { 1, "Financiero" });

            migrationBuilder.InsertData(
                table: "Departamento",
                columns: new[] { "DepartamentoId", "Descripcion" },
                values: new object[] { 2, "Recursos Humanos" });

            migrationBuilder.InsertData(
                table: "Departamento",
                columns: new[] { "DepartamentoId", "Descripcion" },
                values: new object[] { 3, "Compras" });

            migrationBuilder.InsertData(
                table: "Departamento",
                columns: new[] { "DepartamentoId", "Descripcion" },
                values: new object[] { 4, "Administrador" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RolId", "Descripcion" },
                values: new object[] { 1, "Gerente" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RolId", "Descripcion" },
                values: new object[] { 2, "Secreatrio" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RolId", "Descripcion" },
                values: new object[] { 3, "Contable" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RolId", "Descripcion" },
                values: new object[] { 4, "Desarrollador" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RolId", "Descripcion" },
                values: new object[] { 5, "Desarrollador" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Nomina");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
