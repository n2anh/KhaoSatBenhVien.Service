using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KhaoSatBenhVien.Models
{
    public class CanBoBenhVien
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        [StringLength(100)]
        public string TenCanBo { get; set; }



        [StringLength(200)]
        public string ChucVu { get; set; }


        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        public int BoPhanId { get; set; }

        public List<PhanQuyen> PhanQuyens { get; set; }
    }
}
