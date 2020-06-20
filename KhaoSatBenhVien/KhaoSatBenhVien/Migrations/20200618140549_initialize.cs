using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KhaoSatBenhVien.Migrations
{
    public partial class initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BenhNhans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenBenhNhan = table.Column<string>(maxLength: 100, nullable: false),
                    CMTND = table.Column<string>(maxLength: 12, nullable: false),
                    NgayTao = table.Column<DateTime>(nullable: true),
                    NgayCapNhat = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenhNhans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoPhans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenBoPhan = table.Column<string>(maxLength: 100, nullable: false),
                    DiaDiem = table.Column<string>(maxLength: 200, nullable: true),
                    Logo = table.Column<string>(nullable: false),
                    LoiChao = table.Column<string>(maxLength: 100, nullable: false),
                    AnhNen = table.Column<string>(nullable: true),
                    ThongTinMoTa = table.Column<string>(nullable: true),
                    LichLamViec = table.Column<string>(maxLength: 500, nullable: true),
                    BoPhanId = table.Column<int>(nullable: true),
                    NgayTao = table.Column<DateTime>(nullable: true),
                    NgayCapNhat = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoPhans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoPhans_BoPhans_BoPhanId",
                        column: x => x.BoPhanId,
                        principalTable: "BoPhans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChucNangs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChucNang = table.Column<string>(maxLength: 50, nullable: false),
                    DuongDan = table.Column<string>(maxLength: 200, nullable: false),
                    Icon = table.Column<string>(nullable: false),
                    NgayTao = table.Column<DateTime>(nullable: true),
                    NgayCapNhat = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucNangs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MauKhaoSat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenMauKhaoSat = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MauKhaoSat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MucDoHaiLongs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(nullable: false),
                    NoiDung = table.Column<string>(maxLength: 100, nullable: false),
                    NgayTao = table.Column<DateTime>(nullable: true),
                    NgayCapNhat = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MucDoHaiLongs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quyens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuyen = table.Column<string>(nullable: false),
                    NgayTao = table.Column<DateTime>(nullable: true),
                    NgayCapNhat = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quyens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CanBoBenhViens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCanBo = table.Column<string>(maxLength: 100, nullable: false),
                    ChucVu = table.Column<string>(maxLength: 200, nullable: true),
                    Username = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    BoPhanId = table.Column<int>(nullable: false),
                    NgayTao = table.Column<DateTime>(nullable: true),
                    NgayCapNhat = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanBoBenhViens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CanBoBenhViens_BoPhans_BoPhanId",
                        column: x => x.BoPhanId,
                        principalTable: "BoPhans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhieuDanhGias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BenhNhanId = table.Column<int>(nullable: false),
                    BoPhanId = table.Column<int>(nullable: false),
                    ThoiGianBatDau = table.Column<DateTime>(nullable: false),
                    ThoiGianKetThuc = table.Column<DateTime>(nullable: false),
                    NoiDungDanhGiaKhac = table.Column<string>(nullable: true),
                    AnhDanhGiaKhac = table.Column<string>(nullable: true),
                    NgayTao = table.Column<DateTime>(nullable: true),
                    NgayCapNhat = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuDanhGias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhieuDanhGias_BenhNhans_BenhNhanId",
                        column: x => x.BenhNhanId,
                        principalTable: "BenhNhans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhieuDanhGias_BoPhans_BoPhanId",
                        column: x => x.BoPhanId,
                        principalTable: "BoPhans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CauHoiKhaoSats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(nullable: true),
                    NoiDung = table.Column<string>(maxLength: 100, nullable: false),
                    TrangThai = table.Column<int>(nullable: false),
                    NgayTao = table.Column<DateTime>(nullable: true),
                    NgayCapNhat = table.Column<DateTime>(nullable: true),
                    MauKhaoSatId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauHoiKhaoSats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CauHoiKhaoSats_MauKhaoSat_MauKhaoSatId",
                        column: x => x.MauKhaoSatId,
                        principalTable: "MauKhaoSat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietQuyens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuyenId = table.Column<int>(nullable: false),
                    ChucNangId = table.Column<int>(nullable: false),
                    QuyenXem = table.Column<bool>(nullable: false),
                    QuyenThem = table.Column<bool>(nullable: false),
                    QuyenSua = table.Column<bool>(nullable: false),
                    QuyenXoa = table.Column<bool>(nullable: false),
                    NgayTao = table.Column<DateTime>(nullable: true),
                    NgayCapNhat = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietQuyens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietQuyens_ChucNangs_ChucNangId",
                        column: x => x.ChucNangId,
                        principalTable: "ChucNangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietQuyens_Quyens_QuyenId",
                        column: x => x.QuyenId,
                        principalTable: "Quyens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhanQuyens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CanBoBenhVienId = table.Column<int>(nullable: true),
                    QuyenId = table.Column<int>(nullable: true),
                    NgayTao = table.Column<DateTime>(nullable: true),
                    NgayCapNhat = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanQuyens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhanQuyens_CanBoBenhViens_CanBoBenhVienId",
                        column: x => x.CanBoBenhVienId,
                        principalTable: "CanBoBenhViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhanQuyens_Quyens_QuyenId",
                        column: x => x.QuyenId,
                        principalTable: "Quyens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhieuDanhGias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhieuDanhGiaId = table.Column<int>(nullable: false),
                    CauHoiKhaoSatId = table.Column<int>(nullable: false),
                    MucDoHaiLongId = table.Column<int>(nullable: false),
                    ThoiGianDanhGia = table.Column<DateTime>(nullable: false),
                    NgayTao = table.Column<DateTime>(nullable: true),
                    NgayCapNhat = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietPhieuDanhGias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuDanhGias_CauHoiKhaoSats_CauHoiKhaoSatId",
                        column: x => x.CauHoiKhaoSatId,
                        principalTable: "CauHoiKhaoSats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuDanhGias_MucDoHaiLongs_MucDoHaiLongId",
                        column: x => x.MucDoHaiLongId,
                        principalTable: "MucDoHaiLongs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuDanhGias_PhieuDanhGias_PhieuDanhGiaId",
                        column: x => x.PhieuDanhGiaId,
                        principalTable: "PhieuDanhGias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoPhans_BoPhanId",
                table: "BoPhans",
                column: "BoPhanId");

            migrationBuilder.CreateIndex(
                name: "IX_CanBoBenhViens_BoPhanId",
                table: "CanBoBenhViens",
                column: "BoPhanId");

            migrationBuilder.CreateIndex(
                name: "IX_CauHoiKhaoSats_MauKhaoSatId",
                table: "CauHoiKhaoSats",
                column: "MauKhaoSatId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuDanhGias_CauHoiKhaoSatId",
                table: "ChiTietPhieuDanhGias",
                column: "CauHoiKhaoSatId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuDanhGias_MucDoHaiLongId",
                table: "ChiTietPhieuDanhGias",
                column: "MucDoHaiLongId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuDanhGias_PhieuDanhGiaId",
                table: "ChiTietPhieuDanhGias",
                column: "PhieuDanhGiaId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietQuyens_ChucNangId",
                table: "ChiTietQuyens",
                column: "ChucNangId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietQuyens_QuyenId",
                table: "ChiTietQuyens",
                column: "QuyenId");

            migrationBuilder.CreateIndex(
                name: "IX_PhanQuyens_CanBoBenhVienId",
                table: "PhanQuyens",
                column: "CanBoBenhVienId");

            migrationBuilder.CreateIndex(
                name: "IX_PhanQuyens_QuyenId",
                table: "PhanQuyens",
                column: "QuyenId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuDanhGias_BenhNhanId",
                table: "PhieuDanhGias",
                column: "BenhNhanId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuDanhGias_BoPhanId",
                table: "PhieuDanhGias",
                column: "BoPhanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietPhieuDanhGias");

            migrationBuilder.DropTable(
                name: "ChiTietQuyens");

            migrationBuilder.DropTable(
                name: "PhanQuyens");

            migrationBuilder.DropTable(
                name: "CauHoiKhaoSats");

            migrationBuilder.DropTable(
                name: "MucDoHaiLongs");

            migrationBuilder.DropTable(
                name: "PhieuDanhGias");

            migrationBuilder.DropTable(
                name: "ChucNangs");

            migrationBuilder.DropTable(
                name: "CanBoBenhViens");

            migrationBuilder.DropTable(
                name: "Quyens");

            migrationBuilder.DropTable(
                name: "MauKhaoSat");

            migrationBuilder.DropTable(
                name: "BenhNhans");

            migrationBuilder.DropTable(
                name: "BoPhans");
        }
    }
}
