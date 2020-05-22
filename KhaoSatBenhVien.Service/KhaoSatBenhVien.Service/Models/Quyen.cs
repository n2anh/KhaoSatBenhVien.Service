using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhaoSatBenhVien.Service.Models
{
    public class Quyen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string TenQuyen { get; set; }

        List<ChiTietQuyen> ChiTietQuyens { get; set; }
        List<PhanQuyen> PhanQuyens { get; set; }
    }
}
