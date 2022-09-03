using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication7.Migrations
{
    public partial class nuevamigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: 1151,
                column: "FechaCreacion",
                value: new DateTime(2022, 8, 29, 17, 6, 22, 8, DateTimeKind.Local).AddTicks(5036));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: 2252,
                column: "FechaCreacion",
                value: new DateTime(2022, 8, 29, 17, 6, 22, 8, DateTimeKind.Local).AddTicks(5048));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: 1151,
                column: "FechaCreacion",
                value: new DateTime(2022, 8, 29, 17, 4, 43, 159, DateTimeKind.Local).AddTicks(4182));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: 2252,
                column: "FechaCreacion",
                value: new DateTime(2022, 8, 29, 17, 4, 43, 159, DateTimeKind.Local).AddTicks(4192));
        }
    }
}
