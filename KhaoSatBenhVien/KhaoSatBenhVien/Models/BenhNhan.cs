using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhaoSatBenhVien.Models
{
    public class BenhNhan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string TenBenhNhan { get; set; }

        [Required]
        [StringLength(12)]
        public string CMTND { get; set; }

        List<PhieuDanhGia> PhieuDanhGias { get; set; }


        public DateTime? NgayTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }

    }
}
