using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Pract20_21.Model;

public partial class TovaryContext : DbContext
{
    public TovaryContext()
    {
    }

    public TovaryContext(DbContextOptions<TovaryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<B1> B1s { get; set; }

    public virtual DbSet<Поставщик> Поставщикs { get; set; }

    public virtual DbSet<Поступления> Поступленияs { get; set; }

    public virtual DbSet<Продажи> Продажиs { get; set; }

    public virtual DbSet<СправочникГруппТоваров> СправочникГруппТоваровs { get; set; }

    public virtual DbSet<Ценник> Ценникs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress; Database=Tovary;User=исп-31;Password=1234567890;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<B1>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("B1");
        });

        modelBuilder.Entity<Поставщик>(entity =>
        {
            entity.HasKey(e => e.КодПоставщика);

            entity.ToTable("Поставщик");

            entity.HasOne(d => d.КодТовараNavigation).WithMany(p => p.Поставщикs)
                .HasForeignKey(d => d.КодТовара)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Поставщик_Ценник");
        });

        modelBuilder.Entity<Поступления>(entity =>
        {
            entity.HasKey(e => e.НомерНакладной);

            entity.ToTable("Поступления");

            entity.Property(e => e.ДатаПоступления).HasColumnType("datetime");

            entity.HasOne(d => d.КодТовараNavigation).WithMany(p => p.Поступленияs)
                .HasForeignKey(d => d.КодТовара)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Поступления_Ценник");
        });

        modelBuilder.Entity<Продажи>(entity =>
        {
            entity.HasKey(e => e.НомерЧека);

            entity.ToTable("Продажи");

            entity.Property(e => e.ДатаПродажи).HasColumnType("datetime");

            entity.HasOne(d => d.КодТовараNavigation).WithMany(p => p.Продажиs)
                .HasForeignKey(d => d.КодТовара)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Продажи_Ценник");
        });

        modelBuilder.Entity<СправочникГруппТоваров>(entity =>
        {
            entity.HasKey(e => e.КодГруппы);

            entity.ToTable("СправочникГруппТоваров");
        });

        modelBuilder.Entity<Ценник>(entity =>
        {
            entity.HasKey(e => e.КодТовара).HasName("PK_Ценник_1");

            entity.ToTable("Ценник");

            entity.Property(e => e.ЕдиницыИзмерения).HasMaxLength(30);
            entity.Property(e => e.Цена).HasColumnType("money");

            entity.HasOne(d => d.КодГруппыNavigation).WithMany(p => p.Ценникs)
                .HasForeignKey(d => d.КодГруппы)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ценник_СправочникГруппТоваров");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
