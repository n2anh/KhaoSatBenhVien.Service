using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhaoSatBenhVien.Models
{
    public class PhanQuyen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public CanBoBenhVien CanBoBenhVien { get; set; }

        public int CanBoBenhVienId { get; set; }

        public Quyen Quyen { get; set; }

        public int QuyenId { get; set; }

        public DateTime? NgayTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }
    }
}
