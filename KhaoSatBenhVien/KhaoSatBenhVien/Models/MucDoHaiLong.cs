﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KhaoSatBenhVien.Models
{
    public class MucDoHaiLong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Logo { get; set; }

        [Required]
        [StringLength(100)]
        public string NoiDung { get; set; }

        public List<ChiTietPhieuDanhGia> ChiTietPhieuDanhGias { get; set; }

        public DateTime? NgayTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }


    }
}
