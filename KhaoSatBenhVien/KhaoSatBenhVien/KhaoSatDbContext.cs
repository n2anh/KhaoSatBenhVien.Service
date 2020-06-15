using KhaoSatBenhVien.Models;
using Microsoft.EntityFrameworkCore;

namespace KhaoSatBenhVien
{
    public class KhaoSatDbContext : DbContext
    {
        public KhaoSatDbContext(DbContextOptions<KhaoSatDbContext> options)
            : base(options)
        { }

        public DbSet<BenhNhan> BenhNhans { get; set; }
        public DbSet<BoPhan> BoPhans { get; set; }
        public DbSet<CanBoBenhVien> CanBoBenhViens { get; set; }
        public DbSet<CauHoiKhaoSat> CauHoiKhaoSats { get; set; }
        public DbSet<ChiTietPhieuDanhGia> ChiTietPhieuDanhGias { get; set; }
        public DbSet<ChiTietQuyen> ChiTietQuyens { get; set; }
        public DbSet<ChucNang> ChucNangs { get; set; }
        public DbSet<MucDoHaiLong> MucDoHaiLongs { get; set; }
        public DbSet<PhanQuyen> PhanQuyens { get; set; }
        public DbSet<PhieuDanhGia> PhieuDanhGias { get; set; }
        public DbSet<Quyen> Quyens { get; set; }
        public DbSet<KhaoSatBenhVien.Models.MauKhaoSat> MauKhaoSat { get; set; }
    }
}
