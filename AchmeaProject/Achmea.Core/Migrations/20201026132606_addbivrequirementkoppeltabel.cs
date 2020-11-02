using Microsoft.EntityFrameworkCore.Migrations;

namespace Achmea.Core.Migrations
{
    public partial class addbivrequirementkoppeltabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BIVRequirement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BivId = table.Column<int>(nullable: false),
                    RequirementId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BIVRequirement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BIVRequirement_BIV_BivId",
                        column: x => x.BivId,
                        principalTable: "BIV",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BIVRequirement_Security_Requirement_RequirementId",
                        column: x => x.RequirementId,
                        principalTable: "Security_Requirement",
                        principalColumn: "RequirementID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BIVRequirement_BivId",
                table: "BIVRequirement",
                column: "BivId");

            migrationBuilder.CreateIndex(
                name: "IX_BIVRequirement_RequirementId",
                table: "BIVRequirement",
                column: "RequirementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BIVRequirement");
        }
    }
}
