using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhaoSatBenhVien.Service.Models
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

        List<PhieuDanhGia> PhieuDanhGias { get; set; }

        List<CauHoiKhaoSat> CauHoiKhaoSats { get; set; }
    }
}
