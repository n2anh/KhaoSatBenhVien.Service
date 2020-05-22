﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhaoSatBenhVien.Service.Models
{
    public class ChucNang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string TenChucNang { get; set; }

        [Required]
        [StringLength(200)]
        public string DuongDan { get; set; }

        [Required]
        public string Icon { get; set; }

        List<ChiTietQuyen> ChiTietQuyens { get; set; }
    }
}
