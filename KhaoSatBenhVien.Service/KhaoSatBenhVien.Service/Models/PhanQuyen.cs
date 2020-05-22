using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhaoSatBenhVien.Service.Models
{
    public class PhanQuyen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public CanBoBenhVien CanBoBenhVien { get; set; }

        public Quyen Quyen { get; set; }
    }
}
