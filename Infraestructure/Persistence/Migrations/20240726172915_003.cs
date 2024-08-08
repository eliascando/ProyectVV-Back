using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_systemParametersDetails_systemParameters_systemParameterId",
                table: "systemParametersDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_systemParametersDetails",
                table: "systemParametersDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_systemParameters",
                table: "systemParameters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_matriculas",
                table: "matriculas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cursos",
                table: "cursos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_calificaciones",
                table: "calificaciones");

            migrationBuilder.DropColumn(
                name: "cityId",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "countryId",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "nationalityId",
                table: "usuarios");

            migrationBuilder.RenameTable(
                name: "usuarios",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "systemParametersDetails",
                newName: "SystemParametersDetails");

            migrationBuilder.RenameTable(
                name: "systemParameters",
                newName: "SystemParameters");

            migrationBuilder.RenameTable(
                name: "matriculas",
                newName: "Matriculas");

            migrationBuilder.RenameTable(
                name: "cursos",
                newName: "Cursos");

            migrationBuilder.RenameTable(
                name: "calificaciones",
                newName: "Calificaciones");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Usuarios",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "roleId",
                table: "Usuarios",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Usuarios",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Usuarios",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "numberIdentification",
                table: "Usuarios",
                newName: "NumberIdentification");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Usuarios",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Usuarios",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Usuarios",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "adress",
                table: "Usuarios",
                newName: "Adress");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Usuarios",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "value",
                table: "SystemParametersDetails",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "systemParameterId",
                table: "SystemParametersDetails",
                newName: "SystemParameterId");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "SystemParametersDetails",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "SystemParametersDetails",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_systemParametersDetails_systemParameterId",
                table: "SystemParametersDetails",
                newName: "IX_SystemParametersDetails_SystemParameterId");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "SystemParameters",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "creationTime",
                table: "SystemParameters",
                newName: "CreationTime");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "SystemParameters",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Matriculas",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "typeId",
                table: "Matriculas",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Matriculas",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "creationTime",
                table: "Matriculas",
                newName: "CreationTime");

            migrationBuilder.RenameColumn(
                name: "courseId",
                table: "Matriculas",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Matriculas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Cursos",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Cursos",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "parallel",
                table: "Cursos",
                newName: "Parallel");

            migrationBuilder.RenameColumn(
                name: "hours",
                table: "Cursos",
                newName: "Hours");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Cursos",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "cycleId",
                table: "Cursos",
                newName: "CycleId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Cursos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Calificaciones",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "matriculaId",
                table: "Calificaciones",
                newName: "MatriculaId");

            migrationBuilder.RenameColumn(
                name: "gradeType",
                table: "Calificaciones",
                newName: "GradeType");

            migrationBuilder.RenameColumn(
                name: "grade",
                table: "Calificaciones",
                newName: "Grade");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Calificaciones",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Adress",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SystemParametersDetails",
                table: "SystemParametersDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SystemParameters",
                table: "SystemParameters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Matriculas",
                table: "Matriculas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cursos",
                table: "Cursos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Calificaciones",
                table: "Calificaciones",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SystemParametersDetails_SystemParameters_SystemParameterId",
                table: "SystemParametersDetails",
                column: "SystemParameterId",
                principalTable: "SystemParameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SystemParametersDetails_SystemParameters_SystemParameterId",
                table: "SystemParametersDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SystemParametersDetails",
                table: "SystemParametersDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SystemParameters",
                table: "SystemParameters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Matriculas",
                table: "Matriculas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cursos",
                table: "Cursos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Calificaciones",
                table: "Calificaciones");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "usuarios");

            migrationBuilder.RenameTable(
                name: "SystemParametersDetails",
                newName: "systemParametersDetails");

            migrationBuilder.RenameTable(
                name: "SystemParameters",
                newName: "systemParameters");

            migrationBuilder.RenameTable(
                name: "Matriculas",
                newName: "matriculas");

            migrationBuilder.RenameTable(
                name: "Cursos",
                newName: "cursos");

            migrationBuilder.RenameTable(
                name: "Calificaciones",
                newName: "calificaciones");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "usuarios",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "usuarios",
                newName: "roleId");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "usuarios",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "usuarios",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "NumberIdentification",
                table: "usuarios",
                newName: "numberIdentification");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "usuarios",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "usuarios",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "usuarios",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "usuarios",
                newName: "adress");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "usuarios",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "systemParametersDetails",
                newName: "value");

            migrationBuilder.RenameColumn(
                name: "SystemParameterId",
                table: "systemParametersDetails",
                newName: "systemParameterId");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "systemParametersDetails",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "systemParametersDetails",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_SystemParametersDetails_SystemParameterId",
                table: "systemParametersDetails",
                newName: "IX_systemParametersDetails_systemParameterId");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "systemParameters",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "systemParameters",
                newName: "creationTime");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "systemParameters",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "matriculas",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "matriculas",
                newName: "typeId");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "matriculas",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "matriculas",
                newName: "creationTime");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "matriculas",
                newName: "courseId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "matriculas",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "cursos",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "cursos",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Parallel",
                table: "cursos",
                newName: "parallel");

            migrationBuilder.RenameColumn(
                name: "Hours",
                table: "cursos",
                newName: "hours");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "cursos",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "CycleId",
                table: "cursos",
                newName: "cycleId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "cursos",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "calificaciones",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "MatriculaId",
                table: "calificaciones",
                newName: "matriculaId");

            migrationBuilder.RenameColumn(
                name: "GradeType",
                table: "calificaciones",
                newName: "gradeType");

            migrationBuilder.RenameColumn(
                name: "Grade",
                table: "calificaciones",
                newName: "grade");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "calificaciones",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "adress",
                table: "usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "cityId",
                table: "usuarios",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "countryId",
                table: "usuarios",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "nationalityId",
                table: "usuarios",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_systemParametersDetails",
                table: "systemParametersDetails",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_systemParameters",
                table: "systemParameters",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_matriculas",
                table: "matriculas",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cursos",
                table: "cursos",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_calificaciones",
                table: "calificaciones",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_systemParametersDetails_systemParameters_systemParameterId",
                table: "systemParametersDetails",
                column: "systemParameterId",
                principalTable: "systemParameters",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
