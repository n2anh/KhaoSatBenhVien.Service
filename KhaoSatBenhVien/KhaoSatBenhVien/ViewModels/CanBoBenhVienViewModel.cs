using KhaoSatBenhVien.Models;
using System;

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

        public BoPhanViewModel BoPhan { get; set; }

        public QuyenMapping PhanQuyens { get; set; }

        public DateTime? NgayTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }
    }
}
