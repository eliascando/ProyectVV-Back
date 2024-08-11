using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _013 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatusApprove",
                table: "Matriculas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2024, 8, 10, 17, 58, 2, 312, DateTimeKind.Local).AddTicks(7740));

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationTime",
                value: new DateTime(2024, 8, 10, 17, 58, 2, 312, DateTimeKind.Local).AddTicks(7755));

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationTime",
                value: new DateTime(2024, 8, 10, 17, 58, 2, 312, DateTimeKind.Local).AddTicks(7757));

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationTime",
                value: new DateTime(2024, 8, 10, 17, 58, 2, 312, DateTimeKind.Local).AddTicks(7758));

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationTime",
                value: new DateTime(2024, 8, 10, 17, 58, 2, 312, DateTimeKind.Local).AddTicks(7759));

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationTime",
                value: new DateTime(2024, 8, 10, 17, 58, 2, 312, DateTimeKind.Local).AddTicks(7760));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1L,
                column: "NumberIdentification",
                value: "0000");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusApprove",
                table: "Matriculas");

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2024, 8, 8, 2, 52, 16, 89, DateTimeKind.Local).AddTicks(8151));

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationTime",
                value: new DateTime(2024, 8, 8, 2, 52, 16, 89, DateTimeKind.Local).AddTicks(8165));

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationTime",
                value: new DateTime(2024, 8, 8, 2, 52, 16, 89, DateTimeKind.Local).AddTicks(8166));

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationTime",
                value: new DateTime(2024, 8, 8, 2, 52, 16, 89, DateTimeKind.Local).AddTicks(8167));

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationTime",
                value: new DateTime(2024, 8, 8, 2, 52, 16, 89, DateTimeKind.Local).AddTicks(8168));

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationTime",
                value: new DateTime(2024, 8, 8, 2, 52, 16, 89, DateTimeKind.Local).AddTicks(8169));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1L,
                column: "NumberIdentification",
                value: "admin");
        }
    }
}
