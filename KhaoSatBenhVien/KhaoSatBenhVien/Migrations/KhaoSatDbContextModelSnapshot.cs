﻿// <auto-generated />
using System;
using KhaoSatBenhVien;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KhaoSatBenhVien.Migrations
{
    [DbContext(typeof(KhaoSatDbContext))]
    partial class KhaoSatDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KhaoSatBenhVien.Models.BenhNhan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CMTND")
                        .IsRequired()
                        .HasColumnType("nvarchar(12)")
                        .HasMaxLength(12);

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenBenhNhan")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("BenhNhans");
                });

            modelBuilder.Entity("KhaoSatBenhVien.Models.BoPhan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnhNen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BoPhanId")
                        .HasColumnType("int");

                    b.Property<string>("DiaDiem")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("LichLamViec")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LoiChao")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenBoPhan")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("ThongTinMoTa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BoPhanId");

                    b.ToTable("BoPhans");
                });

            modelBuilder.Entity("KhaoSatBenhVien.Models.CanBoBenhVien", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BoPhanId")
                        .HasColumnType("int");

                    b.Property<string>("ChucVu")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("TenCanBo")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("BoPhanId");

                    b.ToTable("CanBoBenhViens");
                });

            modelBuilder.Entity("KhaoSatBenhVien.Models.CauHoiKhaoSat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("CauHoiKhaoSats");
                });

            modelBuilder.Entity("KhaoSatBenhVien.Models.ChiTietPhieuDanhGia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CauHoiKhaoSatId")
                        .HasColumnType("int");

                    b.Property<int>("MucDoHaiLongId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<int>("PhieuDanhGiaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ThoiGianDanhGia")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CauHoiKhaoSatId");

                    b.HasIndex("MucDoHaiLongId");

                    b.HasIndex("PhieuDanhGiaId");

                    b.ToTable("ChiTietPhieuDanhGias");
                });

            modelBuilder.Entity("KhaoSatBenhVien.Models.ChiTietQuyen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChucNangId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<int>("QuyenId")
                        .HasColumnType("int");

                    b.Property<bool>("QuyenSua")
                        .HasColumnType("bit");

                    b.Property<bool>("QuyenThem")
                        .HasColumnType("bit");

                    b.Property<bool>("QuyenXem")
                        .HasColumnType("bit");

                    b.Property<bool>("QuyenXoa")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ChucNangId");

                    b.HasIndex("QuyenId");

                    b.ToTable("ChiTietQuyens");
                });

            modelBuilder.Entity("KhaoSatBenhVien.Models.ChucNang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DuongDan")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenChucNang")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("ChucNangs");
                });

            modelBuilder.Entity("KhaoSatBenhVien.Models.MucDoHaiLong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("MucDoHaiLongs");
                });

            modelBuilder.Entity("KhaoSatBenhVien.Models.PhanQuyen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CanBoBenhVienId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("QuyenId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CanBoBenhVienId");

                    b.HasIndex("QuyenId");

                    b.ToTable("PhanQuyens");
                });

            modelBuilder.Entity("KhaoSatBenhVien.Models.PhieuDanhGia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnhDanhGiaKhac")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BenhNhanId")
                        .HasColumnType("int");

                    b.Property<int>("BoPhanId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiDungDanhGiaKhac")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ThoiGianBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ThoiGianKetThuc")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BenhNhanId");

                    b.HasIndex("BoPhanId");

                    b.ToTable("PhieuDanhGias");
                });

            modelBuilder.Entity("KhaoSatBenhVien.Models.Quyen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenQuyen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Quyens");
                });

            modelBuilder.Entity("KhaoSatBenhVien.Models.BoPhan", b =>
                {
                    b.HasOne("KhaoSatBenhVien.Models.BoPhan", null)
                        .WithMany("BoPhans")
                        .HasForeignKey("BoPhanId");
                });

            modelBuilder.Entity("KhaoSatBenhVien.Models.CanBoBenhVien", b =>
                {
                    b.HasOne("KhaoSatBenhVien.Models.BoPhan", null)
                        .WithMany("CanBoBenhViens")
                        .HasForeignKey("BoPhanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KhaoSatBenhVien.Models.ChiTietPhieuDanhGia", b =>
                {
                    b.HasOne("KhaoSatBenhVien.Models.CauHoiKhaoSat", "CauHoiKhaoSat")
                        .WithMany()
                        .HasForeignKey("CauHoiKhaoSatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KhaoSatBenhVien.Models.MucDoHaiLong", "MucDoHaiLong")
                        .WithMany("ChiTietPhieuDanhGias")
                        .HasForeignKey("MucDoHaiLongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KhaoSatBenhVien.Models.PhieuDanhGia", "PhieuDanhGia")
                        .WithMany()
                        .HasForeignKey("PhieuDanhGiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KhaoSatBenhVien.Models.ChiTietQuyen", b =>
                {
                    b.HasOne("KhaoSatBenhVien.Models.ChucNang", "ChucNang")
                        .WithMany()
                        .HasForeignKey("ChucNangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KhaoSatBenhVien.Models.Quyen", "Quyen")
                        .WithMany("ChiTietQuyens")
                        .HasForeignKey("QuyenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KhaoSatBenhVien.Models.PhanQuyen", b =>
                {
                    b.HasOne("KhaoSatBenhVien.Models.CanBoBenhVien", "CanBoBenhVien")
                        .WithMany("PhanQuyens")
                        .HasForeignKey("CanBoBenhVienId");

                    b.HasOne("KhaoSatBenhVien.Models.Quyen", "Quyen")
                        .WithMany("PhanQuyens")
                        .HasForeignKey("QuyenId");
                });

            modelBuilder.Entity("KhaoSatBenhVien.Models.PhieuDanhGia", b =>
                {
                    b.HasOne("KhaoSatBenhVien.Models.BenhNhan", "BenhNhan")
                        .WithMany()
                        .HasForeignKey("BenhNhanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KhaoSatBenhVien.Models.BoPhan", "BoPhan")
                        .WithMany("PhieuDanhGias")
                        .HasForeignKey("BoPhanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
