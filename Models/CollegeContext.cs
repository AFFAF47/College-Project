using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ServerConnections.Models
{
    public partial class CollegeContext : DbContext
    {
        public CollegeContext()
        {
        }

        public CollegeContext(DbContextOptions<CollegeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCourse> TblCourses { get; set; } = null!;
        public virtual DbSet<TblFaculty> TblFaculties { get; set; } = null!;
        public virtual DbSet<TblStudent> TblStudents { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= SOULREAPER; Database= College; Trusted_Connection = True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCourse>(entity =>
            {
                entity.ToTable("tblCourse");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblFaculty>(entity =>
            {
                entity.ToTable("tblFaculty");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.TblFaculties)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tblCourse_tblFaculty_CourseId");
            });

            modelBuilder.Entity<TblStudent>(entity =>
            {
                entity.ToTable("tblStudent");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.TblStudents)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tblCourse_tblStudent_CourseId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
