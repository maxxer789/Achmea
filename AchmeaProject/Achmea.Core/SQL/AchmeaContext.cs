using System;
using Achmea.Core.ContextModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;

namespace AchmeaProject.Models
{
    public partial class AchmeaContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AchmeaContext()
        {
        }

        public AchmeaContext(DbContextOptions<AchmeaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Biv> Biv { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<EsaArea> EsaArea { get; set; }
        public virtual DbSet<EsaAreaRequirement> EsaAreaRequirement { get; set; }
        public virtual DbSet<EsaAspect> EsaAspect { get; set; }
        public virtual DbSet<EsaAspectArea> EsaAspectArea { get; set; }
        public virtual DbSet<EsaAspectSecurityRequirement> EsaAspectSecurityRequirement { get; set; }
        public virtual DbSet<FileOfProof> FileOfProof { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProjectBiv> ProjectBiv { get; set; }
        public virtual DbSet<ProjectEsaAspect> ProjectEsaAspect { get; set; }
        public virtual DbSet<SecurityRequirement> SecurityRequirement { get; set; }
        public virtual DbSet<SecurityRequirementProject> SecurityRequirementProject { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<ProjectMember> ProjectMembers { get; set; }
        public virtual DbSet<BIVRequirement> BIVRequirement { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=mssql.fhict.local;Initial Catalog=dbi429901_achmea;Persist Security Info=True;User ID=dbi429901_achmea;Password=achmeagroep");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Biv>(entity =>
            {
                entity.ToTable("BIV");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.Content).HasMaxLength(50);


                entity.Property(e => e.PostDateTime)
                    .HasColumnName("Post_DateTime")
                    .HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_User");
            });

            modelBuilder.Entity<EsaArea>(entity =>
            {
                entity.HasKey(e => e.AreaId);

                entity.ToTable("ESA_Area");

                entity.Property(e => e.AreaId).HasColumnName("AreaID");
            });

            modelBuilder.Entity<EsaAreaRequirement>(entity =>
            {
                entity.ToTable("ESA_Area-Requirement");

                entity.Property(e => e.EsaAreaRequirementId).HasColumnName("ESA_Area-RequirementID");

                entity.Property(e => e.EsaAreaId).HasColumnName("ESA_AreaID");

                entity.Property(e => e.RequirementId).HasColumnName("RequirementID");

                entity.HasOne(d => d.EsaArea)
                    .WithMany(p => p.EsaAreaRequirement)
                    .HasForeignKey(d => d.EsaAreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ESA_Area-Requirement_ESA_Area");

                entity.HasOne(d => d.Requirement)
                    .WithMany(p => p.EsaAreaRequirement)
                    .HasForeignKey(d => d.RequirementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ESA_Area-Requirement_Security_Requirement");
            });

            modelBuilder.Entity<EsaAspect>(entity =>
            {
                entity.HasKey(e => e.AspectId)
                    .HasName("PK_tb_ESA_Aspect");

                entity.ToTable("ESA_Aspect");

                entity.Property(e => e.AspectId).HasColumnName("AspectID");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EsaAspectArea>(entity =>
            {
                entity.ToTable("ESA_Aspect-Area");

                entity.Property(e => e.EsaAspectAreaId).HasColumnName("ESA_Aspect-AreaID");

                entity.Property(e => e.EsaAreaId).HasColumnName("ESA_AreaID");

                entity.Property(e => e.EsaAspectId).HasColumnName("ESA_AspectID");

                entity.HasOne(d => d.EsaArea)
                    .WithMany(p => p.EsaAspectArea)
                    .HasForeignKey(d => d.EsaAreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ESA_Aspect-Area_ESA_Area");

                entity.HasOne(d => d.EsaAspect)
                    .WithMany(p => p.EsaAspectArea)
                    .HasForeignKey(d => d.EsaAspectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ESA_Aspect-Area_ESA_Aspect");
            });

            modelBuilder.Entity<EsaAspectSecurityRequirement>(entity =>
            {
                entity.ToTable("ESA-Aspect-Security_Requirement");

                entity.Property(e => e.EsaAspectSecurityRequirementId).HasColumnName("ESA-Aspect-Security_RequirementID");

                entity.Property(e => e.AspectId).HasColumnName("AspectID");

                entity.Property(e => e.RequirementId).HasColumnName("RequirementID");
            });

            modelBuilder.Entity<FileOfProof>(entity =>
            {
                entity.Property(e => e.FileOfProofId).HasColumnName("FileOfProofID");

                entity.Property(e => e.DocumentTitle).HasMaxLength(50);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.CreationDate).HasColumnType("date");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_Project_tb_Project");
            });

            modelBuilder.Entity<ProjectEsaAspect>(entity =>
            {
                entity.HasKey(e => e.ProjectEsaAspect1)
                    .HasName("PK_tb_Project-ESA-Aspect");

                entity.ToTable("Project-ESA_Aspect");

                entity.Property(e => e.ProjectEsaAspect1).HasColumnName("[Project-ESA-Aspect");

                entity.Property(e => e.AspectId).HasColumnName("AspectID");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.HasOne(d => d.Aspect)
                    .WithMany(p => p.ProjectEsaAspect)
                    .HasForeignKey(d => d.AspectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_Project-ESA_Aspect_tb_ESA_Aspect");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectEsaAspect)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_Project-ESA-Aspect_tb_Project");
            });

            modelBuilder.Entity<SecurityRequirement>(entity =>
            {
                entity.HasKey(e => e.RequirementId)
                    .HasName("PK_Security_Requirements");

                entity.ToTable("Security_Requirement");

                entity.Property(e => e.RequirementId).HasColumnName("RequirementID");

                entity.Property(e => e.Family).HasMaxLength(50);

                entity.Property(e => e.MainGroup).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RequirementNumber).HasMaxLength(50);
            });

            modelBuilder.Entity<SecurityRequirementProject>(entity =>
            {
                entity.ToTable("Security_Requirement-Project");

                entity.Property(e => e.SecurityRequirementProjectId).HasColumnName("Security_Requirement-ProjectID");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.SecurityRequirementId).HasColumnName("Security_RequirementID");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.SecurityRequirementProject)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Security_Requirment-Project_Project");

                entity.HasOne(d => d.SecurityRequirement)
                    .WithMany(p => p.SecurityRequirementProject)
                    .HasForeignKey(d => d.SecurityRequirementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Security_Requirment-Project_Security_Requirement");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.RoleId)
                    .HasColumnName("RoleID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
