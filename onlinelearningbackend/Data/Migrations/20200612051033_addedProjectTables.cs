using Microsoft.EntityFrameworkCore.Migrations;

namespace onlinelearningbackend.Data.Migrations
{
    public partial class addedProjectTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Courses_CourseId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TextMaterials_Courses_CourseId",
                table: "TextMaterials");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TextMaterials");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Tracks",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "TextMaterials",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "TaskSolutions",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "TaskSolutions",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TaskName",
                table: "Tasks",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Tasks",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Tasks",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ProjectModel",
                columns: table => new
                {
                    ProjectModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(nullable: false),
                    ProjectDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectModel", x => x.ProjectModelId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectMaterialModel",
                columns: table => new
                {
                    ProjectMaterialModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PathOnServer = table.Column<string>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectMaterialModel", x => x.ProjectMaterialModelId);
                    table.ForeignKey(
                        name: "FK_ProjectMaterialModel_ProjectModel_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "ProjectModel",
                        principalColumn: "ProjectModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProjectModel",
                columns: table => new
                {
                    UserProjectModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsOwner = table.Column<bool>(nullable: false),
                    myUserModelId = table.Column<string>(nullable: true),
                    ProjectModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProjectModel", x => x.UserProjectModelId);
                    table.ForeignKey(
                        name: "FK_UserProjectModel_ProjectModel_ProjectModelId",
                        column: x => x.ProjectModelId,
                        principalTable: "ProjectModel",
                        principalColumn: "ProjectModelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProjectModel_AspNetUsers_myUserModelId",
                        column: x => x.myUserModelId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMaterialModel_ProjectId",
                table: "ProjectMaterialModel",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProjectModel_ProjectModelId",
                table: "UserProjectModel",
                column: "ProjectModelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProjectModel_myUserModelId",
                table: "UserProjectModel",
                column: "myUserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Courses_CourseId",
                table: "Tasks",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TextMaterials_Courses_CourseId",
                table: "TextMaterials",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Courses_CourseId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TextMaterials_Courses_CourseId",
                table: "TextMaterials");

            migrationBuilder.DropTable(
                name: "ProjectMaterialModel");

            migrationBuilder.DropTable(
                name: "UserProjectModel");

            migrationBuilder.DropTable(
                name: "ProjectModel");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "TaskSolutions");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Tracks",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "TextMaterials",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TextMaterials",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "TaskSolutions",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TaskName",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Tasks",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Tasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Courses_CourseId",
                table: "Tasks",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TextMaterials_Courses_CourseId",
                table: "TextMaterials",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
