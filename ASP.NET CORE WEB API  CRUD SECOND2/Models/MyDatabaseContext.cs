using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_CORE_WEB_API__CRUD_SECOND2.Models;

public partial class MyDatabaseContext : DbContext
{
    public MyDatabaseContext()
    {
    }

    public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_id");

            entity.ToTable("Student");

            entity.Property(e => e.Dateofbirth)
                .HasColumnType("datetime")
                .HasColumnName("DATEOFBIRTH");
            entity.Property(e => e.Fathername)
                .HasMaxLength(255)
                .HasColumnName("FATHERNAME");
            entity.Property(e => e.Mothername)
                .HasMaxLength(255)
                .HasColumnName("MOTHERNAME");
            entity.Property(e => e.Student1)
                .HasMaxLength(255)
                .HasColumnName("STUDENT");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
