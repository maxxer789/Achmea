using Microsoft.EntityFrameworkCore.Migrations;

namespace Achmea.Core.Migrations
{
    public partial class idk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Security_Requirement-Project_SecurityRequirementProjectId",
                table: "Comment");

            migrationBuilder.AlterColumn<int>(
                name: "SecurityRequirementProjectId",
                table: "Comment",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Security_Requirement-Project_SecurityRequirementProjectId",
                table: "Comment",
                column: "SecurityRequirementProjectId",
                principalTable: "Security_Requirement-Project",
                principalColumn: "Security_Requirement-ProjectID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Security_Requirement-Project_SecurityRequirementProjectId",
                table: "Comment");

            migrationBuilder.AlterColumn<int>(
                name: "SecurityRequirementProjectId",
                table: "Comment",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Security_Requirement-Project_SecurityRequirementProjectId",
                table: "Comment",
                column: "SecurityRequirementProjectId",
                principalTable: "Security_Requirement-Project",
                principalColumn: "Security_Requirement-ProjectID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
