using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhaoSatBenhVien.Service.Models
{
    public class PhieuDanhGia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int BenhNhanId { get; set; }
        public int BoPhanId { get; set; }

        [Required]
        public DateTime ThoiGianBatDau { get; set; }
        [Required]
        public DateTime ThoiGianKetThuc { get; set; }
        public string NoiDungDanhGiaKhac{ get; set; }
        public string AnhDanhGiaKhac{ get; set; }

        public BenhNhan BenhNhan { get; set; }
        
        
    }
}
