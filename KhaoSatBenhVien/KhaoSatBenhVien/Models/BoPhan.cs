using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhaoSatBenhVien.Models
{
    public class BoPhan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string TenBoPhan { get; set; }



        [StringLength(200)]
        public string DiaDiem { get; set; }


        [Required]
        public string Logo { get; set; }


        [Required]
        [StringLength(100)]
        public string LoiChao { get; set; }

        public string AnhNen { get; set; }

        public string ThongTinMoTa { get; set; }



        [StringLength(500)]
        public string LichLamViec { get; set; }


        public List<BoPhan> BoPhans { get; set; }

        public List<PhieuDanhGia> PhieuDanhGias { get; set; }


        public List<CanBoBenhVien> CanBoBenhViens { get; set; }

        public DateTime? NgayTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }

    }
}
