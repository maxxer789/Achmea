using Microsoft.EntityFrameworkCore.Migrations;

namespace Achmea.Core.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<int>(
                name: "SecurityRequirementProjectId",
                table: "Comment",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Security_Requirement-Project_SecurityRequirementProjectId",
                table: "Comment",
                column: "SecurityRequirementProjectId",
                principalTable: "Security_Requirement-Project",
                principalColumn: "Security_Requirement-ProjectID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<int>(
                name: "SecurityRequirementProjectId",
                table: "Comment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Security_Requirement-Project_SecurityRequirementProjectId",
                table: "Comment",
                column: "SecurityRequirementProjectId",
                principalTable: "Security_Requirement-Project",
                principalColumn: "Security_Requirement-ProjectID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
