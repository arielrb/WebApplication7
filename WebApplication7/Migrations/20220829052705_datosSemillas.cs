using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication7.Migrations
{
    public partial class datosSemillas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "TareaId", "CategoriaID", "Descripcion", "FechaCreacion", "PrioridadTarea", "Procrastinable", "Titulo" },
                values: new object[] { 1151, 111, null, new DateTime(2022, 8, 29, 2, 27, 5, 403, DateTimeKind.Local).AddTicks(4181), 1, false, "Pago de servicios publicos" });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaID", "Descripcion", "FechaCreacion", "PrioridadTarea", "Procrastinable", "Titulo" },
                values: new object[] { 2252, 222, null, new DateTime(2022, 8, 29, 2, 27, 5, 403, DateTimeKind.Local).AddTicks(4190), 2, false, "Terminar de ver pelicula en netflix" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
