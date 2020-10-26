using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Achmea.Core.Migrations
{
    public partial class inintialmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "BIV",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false),
            //        Name = table.Column<string>(unicode: false, maxLength: 10, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_BIV", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ESA_Area",
            //    columns: table => new
            //    {
            //        AreaID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ESA_Area", x => x.AreaID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ESA_Aspect",
            //    columns: table => new
            //    {
            //        AspectID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        Description = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_ESA_Aspect", x => x.AspectID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ESA-Aspect-Security_Requirement",
            //    columns: table => new
            //    {
            //        ESAAspectSecurity_RequirementID = table.Column<int>(name: "ESA-Aspect-Security_RequirementID", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        AspectID = table.Column<int>(nullable: false),
            //        RequirementID = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ESA-Aspect-Security_Requirement", x => x.ESAAspectSecurity_RequirementID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "FileOfProof",
            //    columns: table => new
            //    {
            //        FileOfProofID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        DocumentTitle = table.Column<string>(maxLength: 50, nullable: true),
            //        FileLocation = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_FileOfProof", x => x.FileOfProofID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Security_Requirement",
            //    columns: table => new
            //    {
            //        RequirementID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        Description = table.Column<string>(nullable: true),
            //        Details = table.Column<string>(nullable: true),
            //        Family = table.Column<string>(maxLength: 50, nullable: true),
            //        RequirementNumber = table.Column<string>(maxLength: 50, nullable: true),
            //        MainGroup = table.Column<string>(maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Security_Requirements", x => x.RequirementID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "User",
            //    columns: table => new
            //    {
            //        UserID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Email = table.Column<string>(maxLength: 50, nullable: true),
            //        Password = table.Column<string>(maxLength: 50, nullable: true),
            //        Firstname = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        Lastname = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        PhoneNumber = table.Column<int>(nullable: false),
            //        RoleID = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_User", x => x.UserID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ESA_Aspect-Area",
            //    columns: table => new
            //    {
            //        ESA_AspectAreaID = table.Column<int>(name: "ESA_Aspect-AreaID", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ESA_AspectID = table.Column<int>(nullable: false),
            //        ESA_AreaID = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ESA_Aspect-Area", x => x.ESA_AspectAreaID);
            //        table.ForeignKey(
            //            name: "FK_ESA_Aspect-Area_ESA_Area",
            //            column: x => x.ESA_AreaID,
            //            principalTable: "ESA_Area",
            //            principalColumn: "AreaID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_ESA_Aspect-Area_ESA_Aspect",
            //            column: x => x.ESA_AspectID,
            //            principalTable: "ESA_Aspect",
            //            principalColumn: "AspectID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ESA_Area-Requirement",
            //    columns: table => new
            //    {
            //        ESA_AreaRequirementID = table.Column<int>(name: "ESA_Area-RequirementID", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ESA_AreaID = table.Column<int>(nullable: false),
            //        RequirementID = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ESA_Area-Requirement", x => x.ESA_AreaRequirementID);
            //        table.ForeignKey(
            //            name: "FK_ESA_Area-Requirement_ESA_Area",
            //            column: x => x.ESA_AreaID,
            //            principalTable: "ESA_Area",
            //            principalColumn: "AreaID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_ESA_Area-Requirement_Security_Requirement",
            //            column: x => x.RequirementID,
            //            principalTable: "Security_Requirement",
            //            principalColumn: "RequirementID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Project",
            //    columns: table => new
            //    {
            //        ProjectID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserID = table.Column<int>(nullable: false),
            //        Title = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        Description = table.Column<string>(type: "text", nullable: true),
            //        Status = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        CreationDate = table.Column<DateTime>(type: "date", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Project", x => x.ProjectID);
            //        table.ForeignKey(
            //            name: "FK_tb_Project_tb_Project",
            //            column: x => x.UserID,
            //            principalTable: "User",
            //            principalColumn: "UserID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Comment",
            //    columns: table => new
            //    {
            //        CommentID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FileOfProofID = table.Column<int>(nullable: false),
            //        RequirementID = table.Column<int>(nullable: false),
            //        UserID = table.Column<int>(nullable: false),
            //        ProjectID = table.Column<int>(nullable: false),
            //        Content = table.Column<string>(maxLength: 50, nullable: true),
            //        Post_DateTime = table.Column<DateTime>(type: "date", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Comment", x => x.CommentID);
            //        table.ForeignKey(
            //            name: "FK_Comment_FileOfProof",
            //            column: x => x.FileOfProofID,
            //            principalTable: "FileOfProof",
            //            principalColumn: "FileOfProofID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Comment_Project",
            //            column: x => x.ProjectID,
            //            principalTable: "Project",
            //            principalColumn: "ProjectID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Comment_Security_Requirements",
            //            column: x => x.RequirementID,
            //            principalTable: "Security_Requirement",
            //            principalColumn: "RequirementID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Comment_User",
            //            column: x => x.UserID,
            //            principalTable: "User",
            //            principalColumn: "UserID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Project-ESA_Aspect",
            //    columns: table => new
            //    {
            //        ProjectESAAspect = table.Column<int>(name: "[Project-ESA-Aspect", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProjectID = table.Column<int>(nullable: false),
            //        AspectID = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tb_Project-ESA-Aspect", x => x.ProjectESAAspect);
            //        table.ForeignKey(
            //            name: "FK_tb_Project-ESA_Aspect_tb_ESA_Aspect",
            //            column: x => x.AspectID,
            //            principalTable: "ESA_Aspect",
            //            principalColumn: "AspectID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_tb_Project-ESA-Aspect_tb_Project",
            //            column: x => x.ProjectID,
            //            principalTable: "Project",
            //            principalColumn: "ProjectID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Security_Requirement-Project",
            //    columns: table => new
            //    {
            //        Security_RequirementProjectID = table.Column<int>(name: "Security_Requirement-ProjectID", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProjectID = table.Column<int>(nullable: false),
            //        Security_RequirementID = table.Column<int>(nullable: false),
            //        Excluded = table.Column<bool>(nullable: true),
            //        Reason = table.Column<string>(nullable: true),
            //        Status = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Security_Requirement-Project", x => x.Security_RequirementProjectID);
            //        table.ForeignKey(
            //            name: "FK_Security_Requirment-Project_Project",
            //            column: x => x.ProjectID,
            //            principalTable: "Project",
            //            principalColumn: "ProjectID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Security_Requirment-Project_Security_Requirement",
            //            column: x => x.Security_RequirementID,
            //            principalTable: "Security_Requirement",
            //            principalColumn: "RequirementID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Comment_FileOfProofID",
            //    table: "Comment",
            //    column: "FileOfProofID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Comment_ProjectID",
            //    table: "Comment",
            //    column: "ProjectID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Comment_RequirementID",
            //    table: "Comment",
            //    column: "RequirementID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Comment_UserID",
            //    table: "Comment",
            //    column: "UserID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ESA_Area-Requirement_ESA_AreaID",
            //    table: "ESA_Area-Requirement",
            //    column: "ESA_AreaID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ESA_Area-Requirement_RequirementID",
            //    table: "ESA_Area-Requirement",
            //    column: "RequirementID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ESA_Aspect-Area_ESA_AreaID",
            //    table: "ESA_Aspect-Area",
            //    column: "ESA_AreaID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ESA_Aspect-Area_ESA_AspectID",
            //    table: "ESA_Aspect-Area",
            //    column: "ESA_AspectID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Project_UserID",
            //    table: "Project",
            //    column: "UserID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Project-ESA_Aspect_AspectID",
            //    table: "Project-ESA_Aspect",
            //    column: "AspectID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Project-ESA_Aspect_ProjectID",
            //    table: "Project-ESA_Aspect",
            //    column: "ProjectID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Security_Requirement-Project_ProjectID",
            //    table: "Security_Requirement-Project",
            //    column: "ProjectID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Security_Requirement-Project_Security_RequirementID",
            //    table: "Security_Requirement-Project",
            //    column: "Security_RequirementID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "BIV");

            //migrationBuilder.DropTable(
            //    name: "Comment");

            //migrationBuilder.DropTable(
            //    name: "ESA_Area-Requirement");

            //migrationBuilder.DropTable(
            //    name: "ESA_Aspect-Area");

            //migrationBuilder.DropTable(
            //    name: "ESA-Aspect-Security_Requirement");

            //migrationBuilder.DropTable(
            //    name: "Project-ESA_Aspect");

            //migrationBuilder.DropTable(
            //    name: "Security_Requirement-Project");

            //migrationBuilder.DropTable(
            //    name: "FileOfProof");

            //migrationBuilder.DropTable(
            //    name: "ESA_Area");

            //migrationBuilder.DropTable(
            //    name: "ESA_Aspect");

            //migrationBuilder.DropTable(
            //    name: "Project");

            //migrationBuilder.DropTable(
            //    name: "Security_Requirement");

            //migrationBuilder.DropTable(
            //    name: "User");
        }
    }
}
