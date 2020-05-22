using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhaoSatBenhVien.Service.Models
{
    public class ChiTietPhieuDanhGia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PhieuDanhGiaId { get; set; }
        public int CauHoiKhaoSatId { get; set; }
        public int MucDoHaiLongId { get; set; }

        [Required]
        public DateTime ThoiGianDanhGia { get; set; }

        public PhieuDanhGia PhieuDanhGia { get; set; }

        public CauHoiKhaoSat CauHoiKhaoSat { get; set; }

    }
}
