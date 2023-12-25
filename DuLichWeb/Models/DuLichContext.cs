using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DuLichWeb.Models;

public partial class DuLichContext : DbContext
{
    public DuLichContext()
    {
    }

    public DuLichContext(DbContextOptions<DuLichContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BaiDang> BaiDangs { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-2URTH03\\SQLEXPRESS;Database=DuLich;Integrated security=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaiDang>(entity =>
        {
            entity.HasKey(e => e.BaiDangId).HasName("PK__BaiDang__24EA7A33B22A26FA");

            entity.ToTable("BaiDang");

            entity.Property(e => e.BaiDangId).HasColumnName("BaiDangID");
            entity.Property(e => e.NgayBatDau).HasColumnType("date");
            entity.Property(e => e.NgayKetThuc).HasColumnType("date");
            entity.Property(e => e.Uemail)
                .HasMaxLength(200)
                .HasColumnName("UEmail");

            entity.HasOne(d => d.UemailNavigation).WithMany(p => p.BaiDangs)
                .HasForeignKey(d => d.Uemail)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BaiDang__UEmail__4AB81AF0");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Booking__73951ACD136ACF1D");

            entity.ToTable("Booking");

            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.BaiDangId).HasColumnName("BaiDangID");
            entity.Property(e => e.NguoiBook).HasMaxLength(200);

            entity.HasOne(d => d.BaiDang).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.BaiDangId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Booking__BaiDang__4D94879B");

            entity.HasOne(d => d.NguoiBookNavigation).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.NguoiBook)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Booking__NguoiBo__4E88ABD4");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.UserEmail).HasName("PK__TaiKhoan__08638DF950EB6336");

            entity.ToTable("TaiKhoan");

            entity.Property(e => e.UserEmail).HasMaxLength(200);
            entity.Property(e => e.UserName).HasMaxLength(50);
            entity.Property(e => e.UserPass).HasMaxLength(20);
            entity.Property(e => e.UserPhone).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
