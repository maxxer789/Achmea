using Microsoft.EntityFrameworkCore.Migrations;

namespace Achmea.Core.Migrations
{
    public partial class nullableFildeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Security_Requirement-Project_FileOfProof_FileOfProofId",
                table: "Security_Requirement-Project");

            migrationBuilder.AlterColumn<int>(
                name: "FileOfProofId",
                table: "Security_Requirement-Project",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Security_Requirement-Project_FileOfProof_FileOfProofId",
                table: "Security_Requirement-Project",
                column: "FileOfProofId",
                principalTable: "FileOfProof",
                principalColumn: "FileOfProofID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Security_Requirement-Project_FileOfProof_FileOfProofId",
                table: "Security_Requirement-Project");

            migrationBuilder.AlterColumn<int>(
                name: "FileOfProofId",
                table: "Security_Requirement-Project",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Security_Requirement-Project_FileOfProof_FileOfProofId",
                table: "Security_Requirement-Project",
                column: "FileOfProofId",
                principalTable: "FileOfProof",
                principalColumn: "FileOfProofID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
