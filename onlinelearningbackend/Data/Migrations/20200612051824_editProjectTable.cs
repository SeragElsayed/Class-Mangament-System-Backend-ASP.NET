using Microsoft.EntityFrameworkCore.Migrations;

namespace onlinelearningbackend.Data.Migrations
{
    public partial class editProjectTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrackId",
                table: "ProjectModel",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectModel_TrackId",
                table: "ProjectModel",
                column: "TrackId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModel_Tracks_TrackId",
                table: "ProjectModel",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "TrackId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModel_Tracks_TrackId",
                table: "ProjectModel");

            migrationBuilder.DropIndex(
                name: "IX_ProjectModel_TrackId",
                table: "ProjectModel");

            migrationBuilder.DropColumn(
                name: "TrackId",
                table: "ProjectModel");
        }
    }
}
