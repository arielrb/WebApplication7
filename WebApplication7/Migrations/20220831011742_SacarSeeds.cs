using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication7.Migrations
{
    public partial class SacarSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: 1151);

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: 2252);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaID",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaID",
                keyValue: 222);

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaID", "Descripcion", "Nombre" },
                values: new object[] { 120, "Lo que tengo que hacer", "Asuntos personales" });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaID", "Descripcion", "Nombre" },
                values: new object[] { 240, "Lo que me obligan a hacer", "Asutos laborales" });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaID", "Descripcion", "Estado", "FechaCreacion", "PrioridadTarea", "Procrastinable", "Titulo" },
                values: new object[] { 1450, 120, null, false, new DateTime(2022, 8, 30, 22, 17, 41, 872, DateTimeKind.Local).AddTicks(4473), 0, false, "Cebar mates" });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaID", "Descripcion", "Estado", "FechaCreacion", "PrioridadTarea", "Procrastinable", "Titulo" },
                values: new object[] { 2350, 240, null, false, new DateTime(2022, 8, 30, 22, 17, 41, 872, DateTimeKind.Local).AddTicks(4484), 0, false, "Terminar de prerpara la minimal API" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: 1450);

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: 2350);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaID",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaID",
                keyValue: 240);

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaID", "Descripcion", "Nombre" },
                values: new object[] { 111, "Puki", "Tuki" });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaID", "Descripcion", "Nombre" },
                values: new object[] { 222, "Pukieee", "Tukiee" });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaID", "Descripcion", "Estado", "FechaCreacion", "PrioridadTarea", "Procrastinable", "Titulo" },
                values: new object[] { 1151, 111, null, false, new DateTime(2022, 8, 29, 17, 6, 22, 8, DateTimeKind.Local).AddTicks(5036), 1, false, "Pago de servicios publicos" });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaID", "Descripcion", "Estado", "FechaCreacion", "PrioridadTarea", "Procrastinable", "Titulo" },
                values: new object[] { 2252, 222, null, false, new DateTime(2022, 8, 29, 17, 6, 22, 8, DateTimeKind.Local).AddTicks(5048), 2, false, "Terminar de ver pelicula en netflix" });
        }
    }
}
