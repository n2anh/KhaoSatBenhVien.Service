using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KhaoSatBenhVien.Models
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
