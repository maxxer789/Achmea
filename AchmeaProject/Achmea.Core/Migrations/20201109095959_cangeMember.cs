using Microsoft.EntityFrameworkCore.Migrations;

namespace Achmea.Core.Migrations
{
    public partial class cangeMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "ProjectMembers");

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "ProjectMembers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userId",
                table: "ProjectMembers");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "ProjectMembers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
