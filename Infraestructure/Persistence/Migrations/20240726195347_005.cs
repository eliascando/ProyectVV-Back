using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _005 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SystemParametersDetails_SystemParameters_SystemParameterId",
                table: "SystemParametersDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SystemParametersDetails",
                table: "SystemParametersDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SystemParameters",
                table: "SystemParameters");

            migrationBuilder.RenameTable(
                name: "SystemParametersDetails",
                newName: "SystemParameterDetails");

            migrationBuilder.RenameTable(
                name: "SystemParameters",
                newName: "SystemParameter");

            migrationBuilder.RenameIndex(
                name: "IX_SystemParametersDetails_SystemParameterId",
                table: "SystemParameterDetails",
                newName: "IX_SystemParameterDetails_SystemParameterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SystemParameterDetails",
                table: "SystemParameterDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SystemParameter",
                table: "SystemParameter",
                column: "Id");

            migrationBuilder.InsertData(
                table: "SystemParameter",
                columns: new[] { "Id", "CreationTime", "Description" },
                values: new object[] { 1L, new DateTime(2024, 7, 26, 14, 53, 46, 577, DateTimeKind.Local).AddTicks(2148), "Roles" });

            migrationBuilder.InsertData(
                table: "SystemParameterDetails",
                columns: new[] { "Id", "Description", "SystemParameterId", "Value" },
                values: new object[,]
                {
                    { 1L, "Docente", 1L, "DOC" },
                    { 2L, "Estudiante", 1L, "EST" },
                    { 3L, "Secretaria", 1L, "SEC" },
                    { 4L, "Administrador", 1L, "ADM" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_SystemParameterDetails_SystemParameter_SystemParameterId",
                table: "SystemParameterDetails",
                column: "SystemParameterId",
                principalTable: "SystemParameter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SystemParameterDetails_SystemParameter_SystemParameterId",
                table: "SystemParameterDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SystemParameterDetails",
                table: "SystemParameterDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SystemParameter",
                table: "SystemParameter");

            migrationBuilder.DeleteData(
                table: "SystemParameterDetails",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "SystemParameterDetails",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "SystemParameterDetails",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "SystemParameterDetails",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "SystemParameter",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.RenameTable(
                name: "SystemParameterDetails",
                newName: "SystemParametersDetails");

            migrationBuilder.RenameTable(
                name: "SystemParameter",
                newName: "SystemParameters");

            migrationBuilder.RenameIndex(
                name: "IX_SystemParameterDetails_SystemParameterId",
                table: "SystemParametersDetails",
                newName: "IX_SystemParametersDetails_SystemParameterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SystemParametersDetails",
                table: "SystemParametersDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SystemParameters",
                table: "SystemParameters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SystemParametersDetails_SystemParameters_SystemParameterId",
                table: "SystemParametersDetails",
                column: "SystemParameterId",
                principalTable: "SystemParameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
