using KhaoSatBenhVien.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhaoSatBenhVien.Models
{
    public class CauHoiKhaoSat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Logo { get; set; }

        [Required]
        [StringLength(100)]
        public string NoiDung { get; set; }

        public Status Status { get; set; }

        public DateTime? NgayTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }

        public int MauKhaoSatId { get; set; }

        public MauKhaoSat MauKhaoSat { get; set; }


    }
}
