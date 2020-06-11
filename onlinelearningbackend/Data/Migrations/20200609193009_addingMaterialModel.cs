using Microsoft.EntityFrameworkCore.Migrations;

namespace onlinelearningbackend.Data.Migrations
{
    public partial class addingMaterialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "TextMaterials",
                newName: "IsActive");

            migrationBuilder.CreateTable(
                name: "CourseMaterialModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PathOnServer = table.Column<string>(nullable: true),
                    CourseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseMaterialModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseMaterialModel_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseMaterialModel_CourseId",
                table: "CourseMaterialModel",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseMaterialModel");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "TextMaterials",
                newName: "isActive");
        }
    }
}
