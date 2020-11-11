using Microsoft.EntityFrameworkCore.Migrations;

namespace Achmea.Core.Migrations
{
    public partial class CommentsAndFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_FileOfProof",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Project",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Security_Requirements",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "ProjectID",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "RequirementID",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "FileOfProofID",
                table: "Comment",
                newName: "FileOfProofId");

            migrationBuilder.AddColumn<int>(
                name: "FileOfProofId",
                table: "Security_Requirement-Project",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "FileOfProofId",
                table: "Comment",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comment",
                type: "nvarchar(MAX)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecurityRequirementId",
                table: "Comment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecurityRequirementProjectId",
                table: "Comment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Security_Requirement-Project_FileOfProofId",
                table: "Security_Requirement-Project",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Security_Requirement-Project_FileOfProof_FileOfProofId",
                table: "Security_Requirement-Project",
                column: "FileOfProofId",
                principalTable: "FileOfProof",
                principalColumn: "FileOfProofID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_FileOfProof_FileOfProofId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Security_Requirement-Project_SecurityRequirementId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Security_Requirement-Project_FileOfProof_FileOfProofId",
                table: "Security_Requirement-Project");

            migrationBuilder.DropIndex(
                name: "IX_Security_Requirement-Project_FileOfProofId",
                table: "Security_Requirement-Project");

            migrationBuilder.DropIndex(
                name: "IX_Comment_SecurityRequirementId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "FileOfProofId",
                table: "Security_Requirement-Project");

            migrationBuilder.DropColumn(
                name: "SecurityRequirementId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "SecurityRequirementProjectId",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "FileOfProofId",
                table: "Comment",
                newName: "FileOfProofID");
            
            migrationBuilder.AlterColumn<int>(
                name: "FileOfProofID",
                table: "Comment",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comment",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectID",
                table: "Comment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequirementID",
                table: "Comment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_FileOfProof",
                table: "Comment",
                column: "FileOfProofID",
                principalTable: "FileOfProof",
                principalColumn: "FileOfProofID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Project",
                table: "Comment",
                column: "ProjectID",
                principalTable: "Project",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Security_Requirements",
                table: "Comment",
                column: "RequirementID",
                principalTable: "Security_Requirement",
                principalColumn: "RequirementID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
