using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _008 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2024, 7, 26, 19, 32, 56, 233, DateTimeKind.Local).AddTicks(6587));

            migrationBuilder.InsertData(
                table: "SystemParameters",
                columns: new[] { "Id", "CreationTime", "Description" },
                values: new object[] { 2L, new DateTime(2024, 7, 26, 19, 32, 56, 233, DateTimeKind.Local).AddTicks(6607), "Ciclos" });

            migrationBuilder.InsertData(
                table: "SystemParameterDetails",
                columns: new[] { "Id", "Description", "SystemParameterId", "Value" },
                values: new object[,]
                {
                    { 5L, "CICLO I - 2023", 2L, "DOC" },
                    { 6L, "CICLO II - 2023", 2L, "EST" },
                    { 7L, "CICLO I - 2024", 2L, "SEC" },
                    { 8L, "CICLO II - 2024", 2L, "ADM" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemParameterDetails",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "SystemParameterDetails",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "SystemParameterDetails",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "SystemParameterDetails",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2024, 7, 26, 19, 28, 47, 417, DateTimeKind.Local).AddTicks(870));
        }
    }
}
