﻿// <auto-generated />
using System;
using AchmeaProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Achmea.Core.Migrations
{
    [DbContext(typeof(AchmeaContext))]
    [Migration("20201109095959_cangeMember")]
    partial class cangeMember
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Achmea.Core.ContextModels.BIVRequirement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BivId")
                        .HasColumnType("int");

                    b.Property<int>("RequirementId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BivId");

                    b.HasIndex("RequirementId");

                    b.ToTable("BIVRequirement");
                });

            modelBuilder.Entity("Achmea.Core.ContextModels.ProjectMembers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectMembers");
                });

            modelBuilder.Entity("AchmeaProject.Models.Biv", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("BIV");
                });

            modelBuilder.Entity("AchmeaProject.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CommentID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("FileOfProofId")
                        .HasColumnName("FileOfProofID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PostDateTime")
                        .HasColumnName("Post_DateTime")
                        .HasColumnType("date");

                    b.Property<int>("ProjectId")
                        .HasColumnName("ProjectID")
                        .HasColumnType("int");

                    b.Property<int>("RequirementId")
                        .HasColumnName("RequirementID")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnName("UserID")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("FileOfProofId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("RequirementId");

                    b.HasIndex("UserId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("AchmeaProject.Models.EsaArea", b =>
                {
                    b.Property<int>("AreaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AreaID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AreaId");

                    b.ToTable("ESA_Area");
                });

            modelBuilder.Entity("AchmeaProject.Models.EsaAreaRequirement", b =>
                {
                    b.Property<int>("EsaAreaRequirementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ESA_Area-RequirementID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EsaAreaId")
                        .HasColumnName("ESA_AreaID")
                        .HasColumnType("int");

                    b.Property<int>("RequirementId")
                        .HasColumnName("RequirementID")
                        .HasColumnType("int");

                    b.HasKey("EsaAreaRequirementId");

                    b.HasIndex("EsaAreaId");

                    b.HasIndex("RequirementId");

                    b.ToTable("ESA_Area-Requirement");
                });

            modelBuilder.Entity("AchmeaProject.Models.EsaAspect", b =>
                {
                    b.Property<int>("AspectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AspectID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("AspectId")
                        .HasName("PK_tb_ESA_Aspect");

                    b.ToTable("ESA_Aspect");
                });

            modelBuilder.Entity("AchmeaProject.Models.EsaAspectArea", b =>
                {
                    b.Property<int>("EsaAspectAreaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ESA_Aspect-AreaID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EsaAreaId")
                        .HasColumnName("ESA_AreaID")
                        .HasColumnType("int");

                    b.Property<int>("EsaAspectId")
                        .HasColumnName("ESA_AspectID")
                        .HasColumnType("int");

                    b.HasKey("EsaAspectAreaId");

                    b.HasIndex("EsaAreaId");

                    b.HasIndex("EsaAspectId");

                    b.ToTable("ESA_Aspect-Area");
                });

            modelBuilder.Entity("AchmeaProject.Models.EsaAspectSecurityRequirement", b =>
                {
                    b.Property<int>("EsaAspectSecurityRequirementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ESA-Aspect-Security_RequirementID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AspectId")
                        .HasColumnName("AspectID")
                        .HasColumnType("int");

                    b.Property<int>("RequirementId")
                        .HasColumnName("RequirementID")
                        .HasColumnType("int");

                    b.HasKey("EsaAspectSecurityRequirementId");

                    b.ToTable("ESA-Aspect-Security_Requirement");
                });

            modelBuilder.Entity("AchmeaProject.Models.FileOfProof", b =>
                {
                    b.Property<int>("FileOfProofId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("FileOfProofID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DocumentTitle")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("FileLocation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FileOfProofId");

                    b.ToTable("FileOfProof");
                });

            modelBuilder.Entity("AchmeaProject.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProjectID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Title")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("UserId")
                        .HasColumnName("UserID")
                        .HasColumnType("int");

                    b.HasKey("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("AchmeaProject.Models.ProjectEsaAspect", b =>
                {
                    b.Property<int>("ProjectEsaAspect1")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("[Project-ESA-Aspect")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AspectId")
                        .HasColumnName("AspectID")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnName("ProjectID")
                        .HasColumnType("int");

                    b.HasKey("ProjectEsaAspect1")
                        .HasName("PK_tb_Project-ESA-Aspect");

                    b.HasIndex("AspectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Project-ESA_Aspect");
                });

            modelBuilder.Entity("AchmeaProject.Models.SecurityRequirement", b =>
                {
                    b.Property<int>("RequirementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("RequirementID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Family")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("MainGroup")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("RequirementNumber")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("RequirementId")
                        .HasName("PK_Security_Requirements");

                    b.ToTable("Security_Requirement");
                });

            modelBuilder.Entity("AchmeaProject.Models.SecurityRequirementProject", b =>
                {
                    b.Property<int>("SecurityRequirementProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Security_Requirement-ProjectID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Excluded")
                        .HasColumnType("bit");

                    b.Property<int>("ProjectId")
                        .HasColumnName("ProjectID")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SecurityRequirementId")
                        .HasColumnName("Security_RequirementID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SecurityRequirementProjectId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("SecurityRequirementId");

                    b.ToTable("Security_Requirement-Project");
                });

            modelBuilder.Entity("AchmeaProject.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UserID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Firstname")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Lastname")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<string>("RoleId")
                        .HasColumnName("RoleID")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Achmea.Core.ContextModels.BIVRequirement", b =>
                {
                    b.HasOne("AchmeaProject.Models.Biv", "Biv")
                        .WithMany()
                        .HasForeignKey("BivId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AchmeaProject.Models.SecurityRequirement", "SecurityRequirement")
                        .WithMany()
                        .HasForeignKey("RequirementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Achmea.Core.ContextModels.ProjectMembers", b =>
                {
                    b.HasOne("AchmeaProject.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AchmeaProject.Models.Comment", b =>
                {
                    b.HasOne("AchmeaProject.Models.FileOfProof", "FileOfProof")
                        .WithMany("Comment")
                        .HasForeignKey("FileOfProofId")
                        .HasConstraintName("FK_Comment_FileOfProof")
                        .IsRequired();

                    b.HasOne("AchmeaProject.Models.Project", "Project")
                        .WithMany("Comment")
                        .HasForeignKey("ProjectId")
                        .HasConstraintName("FK_Comment_Project")
                        .IsRequired();

                    b.HasOne("AchmeaProject.Models.SecurityRequirement", "Requirement")
                        .WithMany("Comment")
                        .HasForeignKey("RequirementId")
                        .HasConstraintName("FK_Comment_Security_Requirements")
                        .IsRequired();

                    b.HasOne("AchmeaProject.Models.User", "User")
                        .WithMany("Comment")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Comment_User")
                        .IsRequired();
                });

            modelBuilder.Entity("AchmeaProject.Models.EsaAreaRequirement", b =>
                {
                    b.HasOne("AchmeaProject.Models.EsaArea", "EsaArea")
                        .WithMany("EsaAreaRequirement")
                        .HasForeignKey("EsaAreaId")
                        .HasConstraintName("FK_ESA_Area-Requirement_ESA_Area")
                        .IsRequired();

                    b.HasOne("AchmeaProject.Models.SecurityRequirement", "Requirement")
                        .WithMany("EsaAreaRequirement")
                        .HasForeignKey("RequirementId")
                        .HasConstraintName("FK_ESA_Area-Requirement_Security_Requirement")
                        .IsRequired();
                });

            modelBuilder.Entity("AchmeaProject.Models.EsaAspectArea", b =>
                {
                    b.HasOne("AchmeaProject.Models.EsaArea", "EsaArea")
                        .WithMany("EsaAspectArea")
                        .HasForeignKey("EsaAreaId")
                        .HasConstraintName("FK_ESA_Aspect-Area_ESA_Area")
                        .IsRequired();

                    b.HasOne("AchmeaProject.Models.EsaAspect", "EsaAspect")
                        .WithMany("EsaAspectArea")
                        .HasForeignKey("EsaAspectId")
                        .HasConstraintName("FK_ESA_Aspect-Area_ESA_Aspect")
                        .IsRequired();
                });

            modelBuilder.Entity("AchmeaProject.Models.Project", b =>
                {
                    b.HasOne("AchmeaProject.Models.User", "User")
                        .WithMany("Project")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_tb_Project_tb_Project")
                        .IsRequired();
                });

            modelBuilder.Entity("AchmeaProject.Models.ProjectEsaAspect", b =>
                {
                    b.HasOne("AchmeaProject.Models.EsaAspect", "Aspect")
                        .WithMany("ProjectEsaAspect")
                        .HasForeignKey("AspectId")
                        .HasConstraintName("FK_tb_Project-ESA_Aspect_tb_ESA_Aspect")
                        .IsRequired();

                    b.HasOne("AchmeaProject.Models.Project", "Project")
                        .WithMany("ProjectEsaAspect")
                        .HasForeignKey("ProjectId")
                        .HasConstraintName("FK_tb_Project-ESA-Aspect_tb_Project")
                        .IsRequired();
                });

            modelBuilder.Entity("AchmeaProject.Models.SecurityRequirementProject", b =>
                {
                    b.HasOne("AchmeaProject.Models.Project", "Project")
                        .WithMany("SecurityRequirementProject")
                        .HasForeignKey("ProjectId")
                        .HasConstraintName("FK_Security_Requirment-Project_Project")
                        .IsRequired();

                    b.HasOne("AchmeaProject.Models.SecurityRequirement", "SecurityRequirement")
                        .WithMany("SecurityRequirementProject")
                        .HasForeignKey("SecurityRequirementId")
                        .HasConstraintName("FK_Security_Requirment-Project_Security_Requirement")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
