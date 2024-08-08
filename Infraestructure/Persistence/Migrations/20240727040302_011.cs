using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _011 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2024, 7, 26, 23, 3, 2, 336, DateTimeKind.Local).AddTicks(4844));

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationTime",
                value: new DateTime(2024, 7, 26, 23, 3, 2, 336, DateTimeKind.Local).AddTicks(4855));

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationTime",
                value: new DateTime(2024, 7, 26, 23, 3, 2, 336, DateTimeKind.Local).AddTicks(4856));

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationTime",
                value: new DateTime(2024, 7, 26, 23, 3, 2, 336, DateTimeKind.Local).AddTicks(4857));

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationTime",
                value: new DateTime(2024, 7, 26, 23, 3, 2, 336, DateTimeKind.Local).AddTicks(4858));

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationTime",
                value: new DateTime(2024, 7, 26, 23, 3, 2, 336, DateTimeKind.Local).AddTicks(4859));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationTime",
                value: new DateTime(2024, 7, 26, 22, 37, 12, 477, DateTimeKind.Local).AddTicks(4737));

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationTime",
                value: new DateTime(2024, 7, 26, 22, 37, 12, 477, DateTimeKind.Local).AddTicks(4739));

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationTime",
                value: new DateTime(2024, 7, 26, 22, 37, 12, 477, DateTimeKind.Local).AddTicks(4740));
        }
    }
}
