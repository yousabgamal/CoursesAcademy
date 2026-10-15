using System;
using System.Collections.Generic;
using CoursesAcademy.Models;
using Microsoft.EntityFrameworkCore;

namespace CoursesAcademy.Contexts;

public partial class CoursesAcademyDBContext : DbContext
{
    public CoursesAcademyDBContext()
    {
    }

    public CoursesAcademyDBContext(DbContextOptions<CoursesAcademyDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<InstructorTeachCourse> InstructorTeachCourses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentTakeCourse> StudentTakeCourses { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server = Server name; Database = Database name; Trusted_Connection = true; TrustServerCertificate = true").UseLazyLoadingProxies();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Course__3214EC07D63938C5");

            entity.ToTable("Course");

            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Name).IsUnicode(false);

            entity.HasOne(d => d.Topic).WithMany(p => p.Courses)
                .HasForeignKey(d => d.TopicId)
                .HasConstraintName("FK__Course__TopicId__34C8D9D1");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC07577E1341");

            entity.ToTable("Department");

            entity.Property(e => e.HiringDate).HasColumnName("Hiring_Date");
            entity.Property(e => e.Name).IsUnicode(false);

            entity.HasOne(d => d.Inst).WithMany(p => p.Departments)
                .HasForeignKey(d => d.InstId)
                .HasConstraintName("FK__Departmen__InstI__35BCFE0A");
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Instruct__3214EC076BE2805F");

            entity.ToTable("Instructor");

            entity.Property(e => e.Address).IsUnicode(false);
            entity.Property(e => e.Bonus).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HourRate)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Hour_Rate");
            entity.Property(e => e.Name).IsUnicode(false);
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Dpt).WithMany(p => p.Instructors)
                .HasForeignKey(d => d.DptId)
                .HasConstraintName("FK__Instructo__DptId__36B12243");
        });

        modelBuilder.Entity<InstructorTeachCourse>(entity =>
        {
            entity.HasKey(e => new { e.InstId, e.CrsId }).HasName("PK__Instruct__2D0EB5EB5630F4FF");

            entity.ToTable("Instructor_Teach_Course");

            entity.HasOne(d => d.Crs).WithMany(p => p.InstructorTeachCourses)
                .HasForeignKey(d => d.CrsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Instructo__CrsId__32E0915F");

            entity.HasOne(d => d.Inst).WithMany(p => p.InstructorTeachCourses)
                .HasForeignKey(d => d.InstId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Instructo__InstI__31EC6D26");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC07CF132309");

            entity.ToTable("Student");

            entity.Property(e => e.Address).IsUnicode(false);
            entity.Property(e => e.Fname)
                .IsUnicode(false)
                .HasColumnName("FName");
            entity.Property(e => e.Lname)
                .IsUnicode(false)
                .HasColumnName("LName");

            entity.HasOne(d => d.Dpt).WithMany(p => p.Students)
                .HasForeignKey(d => d.DptId)
                .HasConstraintName("FK__Student__DptId__33D4B598");
        });

        modelBuilder.Entity<StudentTakeCourse>(entity =>
        {
            entity.HasKey(e => new { e.StdId, e.CrsId }).HasName("PK__Student___9A708D720F95A704");

            entity.ToTable("Student_Take_Course");

            entity.HasOne(d => d.Crs).WithMany(p => p.StudentTakeCourses)
                .HasForeignKey(d => d.CrsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Student_T__CrsId__2F10007B");

            entity.HasOne(d => d.Std).WithMany(p => p.StudentTakeCourses)
                .HasForeignKey(d => d.StdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Student_T__StdId__2E1BDC42");
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Topic__3214EC07C7B52836");

            entity.ToTable("Topic");

            entity.Property(e => e.Name).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
