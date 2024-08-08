using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _009 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SystemParameterDetails",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Value",
                value: "CI2023");

            migrationBuilder.UpdateData(
                table: "SystemParameterDetails",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Value",
                value: "CII2023");

            migrationBuilder.UpdateData(
                table: "SystemParameterDetails",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Value",
                value: "CI2024");

            migrationBuilder.UpdateData(
                table: "SystemParameterDetails",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Value",
                value: "CII2024");

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2024, 7, 26, 20, 45, 34, 233, DateTimeKind.Local).AddTicks(9022));

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationTime",
                value: new DateTime(2024, 7, 26, 20, 45, 34, 233, DateTimeKind.Local).AddTicks(9032));

            migrationBuilder.InsertData(
                table: "SystemParameters",
                columns: new[] { "Id", "CreationTime", "Description" },
                values: new object[] { 3L, new DateTime(2024, 7, 26, 20, 45, 34, 233, DateTimeKind.Local).AddTicks(9033), "Matriculas" });

            migrationBuilder.InsertData(
                table: "SystemParameterDetails",
                columns: new[] { "Id", "Description", "SystemParameterId", "Value" },
                values: new object[,]
                {
                    { 9L, "DOCENTE", 3L, "MAT-DOC" },
                    { 10L, "ESTUDIANTE", 3L, "MAT-EST" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemParameterDetails",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "SystemParameterDetails",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.UpdateData(
                table: "SystemParameterDetails",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Value",
                value: "DOC");

            migrationBuilder.UpdateData(
                table: "SystemParameterDetails",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Value",
                value: "EST");

            migrationBuilder.UpdateData(
                table: "SystemParameterDetails",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Value",
                value: "SEC");

            migrationBuilder.UpdateData(
                table: "SystemParameterDetails",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Value",
                value: "ADM");

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2024, 7, 26, 19, 32, 56, 233, DateTimeKind.Local).AddTicks(6587));

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationTime",
                value: new DateTime(2024, 7, 26, 19, 32, 56, 233, DateTimeKind.Local).AddTicks(6607));
        }
    }
}
