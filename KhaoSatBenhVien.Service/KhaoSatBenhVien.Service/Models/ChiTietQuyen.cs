using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhaoSatBenhVien.Service.Models
{
    public class ChiTietQuyen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int QuyenId { get; set; }
        public int ChucNangId { get; set; }

        [Required]

        public bool QuyenXem { get; set; }

        [Required]
        public bool QuyenThem { get; set; }

        [Required]
        public bool QuyenSua { get; set; }

        [Required]
        public bool QuyenXoa { get; set; }

        public Quyen Quyen { get; set; }
        public ChucNang ChucNang { get; set; }

    }
}
