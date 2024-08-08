using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _006 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SystemParameterDetails_SystemParameter_SystemParameterId",
                table: "SystemParameterDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SystemParameter",
                table: "SystemParameter");

            migrationBuilder.RenameTable(
                name: "SystemParameter",
                newName: "SystemParameters");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SystemParameters",
                table: "SystemParameters",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2024, 7, 26, 14, 55, 58, 319, DateTimeKind.Local).AddTicks(2300));

            migrationBuilder.AddForeignKey(
                name: "FK_SystemParameterDetails_SystemParameters_SystemParameterId",
                table: "SystemParameterDetails",
                column: "SystemParameterId",
                principalTable: "SystemParameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SystemParameterDetails_SystemParameters_SystemParameterId",
                table: "SystemParameterDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SystemParameters",
                table: "SystemParameters");

            migrationBuilder.RenameTable(
                name: "SystemParameters",
                newName: "SystemParameter");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SystemParameter",
                table: "SystemParameter",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "SystemParameter",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2024, 7, 26, 14, 53, 46, 577, DateTimeKind.Local).AddTicks(2148));

            migrationBuilder.AddForeignKey(
                name: "FK_SystemParameterDetails_SystemParameter_SystemParameterId",
                table: "SystemParameterDetails",
                column: "SystemParameterId",
                principalTable: "SystemParameter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
