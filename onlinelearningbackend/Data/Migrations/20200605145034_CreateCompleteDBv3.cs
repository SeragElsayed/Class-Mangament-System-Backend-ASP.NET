using Microsoft.EntityFrameworkCore.Migrations;

namespace onlinelearningbackend.Data.Migrations
{
    public partial class CreateCompleteDBv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "Tracks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_BranchId",
                table: "Tracks",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Branches_BranchId",
                table: "Tracks",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Branches_BranchId",
                table: "Tracks");

            migrationBuilder.DropIndex(
                name: "IX_Tracks_BranchId",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Tracks");
        }
    }
}
