using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace onlinelearningbackend.Data.Migrations
{
    public partial class CreateCompleteDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TrackId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    BranchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(nullable: true),
                    BranchEmail = table.Column<string>(nullable: true),
                    BranchTelephone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchId);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    TopicId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.TopicId);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    TrackId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.TrackId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IntervalInDays = table.Column<int>(nullable: false),
                    StartingDate = table.Column<DateTime>(nullable: false),
                    EnrollmentKey = table.Column<string>(nullable: true),
                    TopicId = table.Column<int>(nullable: false),
                    TrackId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "TopicId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "TrackId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseMyUserModel",
                columns: table => new
                {
                    CourseMyUserModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(nullable: false),
                    MyUserModelId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseMyUserModel", x => x.CourseMyUserModelId);
                    table.ForeignKey(
                        name: "FK_CourseMyUserModel_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseMyUserModel_AspNetUsers_MyUserModelId",
                        column: x => x.MyUserModelId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LinkMaterials",
                columns: table => new
                {
                    LinkMaterialId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkMaterialName = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    CourseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkMaterials", x => x.LinkMaterialId);
                    table.ForeignKey(
                        name: "FK_LinkMaterials_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false),
                    CourseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Tasks_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TextMaterials",
                columns: table => new
                {
                    TextMaterialId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TextMaterialName = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    CourseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextMaterials", x => x.TextMaterialId);
                    table.ForeignKey(
                        name: "FK_TextMaterials_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VideoMaterials",
                columns: table => new
                {
                    VideoMaterialId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoMaterialName = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    CourseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoMaterials", x => x.VideoMaterialId);
                    table.ForeignKey(
                        name: "FK_VideoMaterials_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskSolutions",
                columns: table => new
                {
                    TaskSolutionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskSolutionURL = table.Column<string>(nullable: true),
                    MyUserModelId = table.Column<string>(nullable: true),
                    CourseId = table.Column<int>(nullable: true),
                    TaskId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskSolutions", x => x.TaskSolutionId);
                    table.ForeignKey(
                        name: "FK_TaskSolutions_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskSolutions_AspNetUsers_MyUserModelId",
                        column: x => x.MyUserModelId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskSolutions_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BranchId",
                table: "AspNetUsers",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TrackId",
                table: "AspNetUsers",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMyUserModel_CourseId",
                table: "CourseMyUserModel",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMyUserModel_MyUserModelId",
                table: "CourseMyUserModel",
                column: "MyUserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TopicId",
                table: "Courses",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TrackId",
                table: "Courses",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkMaterials_CourseId",
                table: "LinkMaterials",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CourseId",
                table: "Tasks",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskSolutions_CourseId",
                table: "TaskSolutions",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskSolutions_MyUserModelId",
                table: "TaskSolutions",
                column: "MyUserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskSolutions_TaskId",
                table: "TaskSolutions",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TextMaterials_CourseId",
                table: "TextMaterials",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoMaterials_CourseId",
                table: "VideoMaterials",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Branches_BranchId",
                table: "AspNetUsers",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tracks_TrackId",
                table: "AspNetUsers",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "TrackId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Branches_BranchId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tracks_TrackId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "CourseMyUserModel");

            migrationBuilder.DropTable(
                name: "LinkMaterials");

            migrationBuilder.DropTable(
                name: "TaskSolutions");

            migrationBuilder.DropTable(
                name: "TextMaterials");

            migrationBuilder.DropTable(
                name: "VideoMaterials");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BranchId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TrackId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TrackId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
