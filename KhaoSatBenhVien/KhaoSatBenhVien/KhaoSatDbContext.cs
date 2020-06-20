using KhaoSatBenhVien.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace KhaoSatBenhVien
{
    public class KhaoSatDbContext : IdentityDbContext<ApplicationUser>
    {

        public KhaoSatDbContext(DbContextOptions<KhaoSatDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Core Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Core Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

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
        public DbSet<MauKhaoSat> MauKhaoSat { get; set; }
    }
}
