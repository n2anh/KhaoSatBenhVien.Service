using KhaoSatBenhVien.Models.Enums;
using System;

namespace KhaoSatBenhVien.ViewModels
{
    public class CauHoiKhaoSatViewModel
    {
       
        public int Id { get; set; }

        public string Logo { get; set; }


        public string NoiDung { get; set; }

        public Status TrangThai { get; set; }

        public DateTime? NgayTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }

        public int? MauKhaoSatId { get; set; }

        public MauKhaoSatViewModel MauKhaoSatViewModel { get; set; }
    }
}
