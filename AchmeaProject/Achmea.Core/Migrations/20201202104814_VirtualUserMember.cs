using Microsoft.EntityFrameworkCore.Migrations;

namespace Achmea.Core.Migrations
{
    public partial class VirtualUserMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userId",
                table: "ProjectMembers",
                newName: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMembers_UserId",
                table: "ProjectMembers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectMembers_User_UserId",
                table: "ProjectMembers",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectMembers_User_UserId",
                table: "ProjectMembers");

            migrationBuilder.DropIndex(
                name: "IX_ProjectMembers_UserId",
                table: "ProjectMembers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ProjectMembers",
                newName: "userId");
        }
    }
}
