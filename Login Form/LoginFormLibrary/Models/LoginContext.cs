using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LoginFormLibrary.Models;

public partial class LoginContext : DbContext
{
    public LoginContext()
    {
    }

    public LoginContext(DbContextOptions<LoginContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Register> Registers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB; database=Login; integrated security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Register>(entity =>
        {
            entity.HasKey(e => e.username).HasName("PK__Register__F3DBC573579B7DA1");

            entity.ToTable("Register");

            entity.Property(e => e.username)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(25)
                .IsUnicode(false);
           
            entity.Property(e => e.psword)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
