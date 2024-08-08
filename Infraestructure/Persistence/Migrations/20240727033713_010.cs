using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _010 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "GradePeriodId",
                table: "Calificaciones",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2024, 7, 26, 22, 37, 12, 477, DateTimeKind.Local).AddTicks(4719));

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationTime",
                value: new DateTime(2024, 7, 26, 22, 37, 12, 477, DateTimeKind.Local).AddTicks(4734));

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationTime",
                value: new DateTime(2024, 7, 26, 22, 37, 12, 477, DateTimeKind.Local).AddTicks(4736));

            migrationBuilder.InsertData(
                table: "SystemParameters",
                columns: new[] { "Id", "CreationTime", "Description" },
                values: new object[,]
                {
                    { 4L, new DateTime(2024, 7, 26, 22, 37, 12, 477, DateTimeKind.Local).AddTicks(4737), "Porcentaje Calificaciones" },
                    { 5L, new DateTime(2024, 7, 26, 22, 37, 12, 477, DateTimeKind.Local).AddTicks(4739), "Tipo Calificaciones" },
                    { 6L, new DateTime(2024, 7, 26, 22, 37, 12, 477, DateTimeKind.Local).AddTicks(4740), "Periodo Calificaciones" }
                });

            migrationBuilder.InsertData(
                table: "SystemParameterDetails",
                columns: new[] { "Id", "Description", "SystemParameterId", "Value" },
                values: new object[,]
                {
                    { 11L, "PORC_FORMATIVA", 4L, "0.33" },
                    { 12L, "PORC_PRACTICA", 4L, "0.33" },
                    { 13L, "PORC_ACREDITACION", 4L, "0.33" },
                    { 14L, "FORMATIVA", 5L, "T_FORM" },
                    { 15L, "PRACTICA", 5L, "T_PRCT" },
                    { 16L, "ACREDITACION", 5L, "T_ACRE" },
                    { 17L, "PROMEDIO", 5L, "T_TTL" },
                    { 18L, "PRIMER PARCIAL", 6L, "1PARC" },
                    { 19L, "SEGUNDO PARCIAL", 6L, "2PARC" },
                    { 20L, "PROMEDIO FINAL", 6L, "0TOT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemParameterDetails",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "SystemParameterDetails",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "SystemParameterDetails",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "SystemParameterDetails",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "SystemParameterDetails",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "SystemParameterDetails",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "SystemParameterDetails",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "SystemParameterDetails",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "SystemParameterDetails",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "SystemParameterDetails",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DropColumn(
                name: "GradePeriodId",
                table: "Calificaciones");

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

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationTime",
                value: new DateTime(2024, 7, 26, 20, 45, 34, 233, DateTimeKind.Local).AddTicks(9033));
        }
    }
}
