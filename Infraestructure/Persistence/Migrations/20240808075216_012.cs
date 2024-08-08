using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _012 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Adress", "Email", "LastName", "Name", "NumberIdentification", "Password", "Phone", "RoleId", "Status" },
                values: new object[] { 1L, null, "admin@admin.com", "", "admin", "0000", "$2a$11$RiVVUuif7kw9we7wayBzDOdSikGRzjmus0xMSuwtraRNH1.zNuiha", null, 4L, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1L);

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
    }
}
