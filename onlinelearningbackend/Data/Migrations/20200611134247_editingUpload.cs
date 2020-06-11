using Microsoft.EntityFrameworkCore.Migrations;

namespace onlinelearningbackend.Data.Migrations
{
    public partial class editingUpload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseMaterialModel_Courses_CourseId",
                table: "CourseMaterialModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseMaterialModel",
                table: "CourseMaterialModel");

            migrationBuilder.RenameTable(
                name: "CourseMaterialModel",
                newName: "CourseMaterialModels");

            migrationBuilder.RenameIndex(
                name: "IX_CourseMaterialModel_CourseId",
                table: "CourseMaterialModels",
                newName: "IX_CourseMaterialModels_CourseId");

            migrationBuilder.AlterColumn<string>(
                name: "PathOnServer",
                table: "CourseMaterialModels",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "CourseMaterialModels",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseMaterialModels",
                table: "CourseMaterialModels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseMaterialModels_Courses_CourseId",
                table: "CourseMaterialModels",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseMaterialModels_Courses_CourseId",
                table: "CourseMaterialModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseMaterialModels",
                table: "CourseMaterialModels");

            migrationBuilder.RenameTable(
                name: "CourseMaterialModels",
                newName: "CourseMaterialModel");

            migrationBuilder.RenameIndex(
                name: "IX_CourseMaterialModels_CourseId",
                table: "CourseMaterialModel",
                newName: "IX_CourseMaterialModel_CourseId");

            migrationBuilder.AlterColumn<string>(
                name: "PathOnServer",
                table: "CourseMaterialModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "CourseMaterialModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseMaterialModel",
                table: "CourseMaterialModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseMaterialModel_Courses_CourseId",
                table: "CourseMaterialModel",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
