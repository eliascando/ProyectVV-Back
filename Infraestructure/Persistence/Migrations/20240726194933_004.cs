using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SystemParametersDetails_SystemParameterId",
                table: "SystemParametersDetails");

            migrationBuilder.CreateIndex(
                name: "IX_SystemParametersDetails_SystemParameterId",
                table: "SystemParametersDetails",
                column: "SystemParameterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SystemParametersDetails_SystemParameterId",
                table: "SystemParametersDetails");

            migrationBuilder.CreateIndex(
                name: "IX_SystemParametersDetails_SystemParameterId",
                table: "SystemParametersDetails",
                column: "SystemParameterId",
                unique: true);
        }
    }
}
