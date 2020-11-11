using Microsoft.EntityFrameworkCore.Migrations;

namespace Achmea.Core.Migrations
{
    public partial class CommentAndFilesTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_FileOfProof_FileOfProofId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Security_Requirement-Project_SecurityRequirementId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_SecurityRequirementId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "FileOfProofId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "SecurityRequirementId",
                table: "Comment");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_SecurityRequirementProjectId",
                table: "Comment",
                column: "SecurityRequirementProjectId");

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
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Security_Requirement-Project_SecurityRequirementProjectId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_SecurityRequirementProjectId",
                table: "Comment");

            migrationBuilder.AddColumn<int>(
                name: "FileOfProofId",
                table: "Comment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecurityRequirementId",
                table: "Comment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_FileOfProofId",
                table: "Comment",
                column: "FileOfProofId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_SecurityRequirementId",
                table: "Comment",
                column: "SecurityRequirementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_FileOfProof_FileOfProofId",
                table: "Comment",
                column: "FileOfProofId",
                principalTable: "FileOfProof",
                principalColumn: "FileOfProofID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Security_Requirement-Project_SecurityRequirementId",
                table: "Comment",
                column: "SecurityRequirementId",
                principalTable: "Security_Requirement-Project",
                principalColumn: "Security_Requirement-ProjectID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
