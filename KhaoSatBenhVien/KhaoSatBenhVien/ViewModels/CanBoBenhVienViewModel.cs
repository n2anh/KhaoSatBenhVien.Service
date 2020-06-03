using KhaoSatBenhVien.Models;
using System.Collections.Generic;

namespace KhaoSatBenhVien.ViewModels
{
    public class CanBoBenhVienViewModel
    {
     
        public int Id { get; set; }

        public string TenCanBo { get; set; }

        public string ChucVu { get; set; }
       
        public string Username { get; set; }

     
        public string Password { get; set; }

        public int BoPhanId { get; set; }

        public BoPhan BoPhan { get; set; }

        public List<PhanQuyen> PhanQuyens { get; set; }
    }
}
