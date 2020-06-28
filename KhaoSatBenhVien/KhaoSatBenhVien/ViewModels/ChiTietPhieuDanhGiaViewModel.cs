using KhaoSatBenhVien.Models;
using System;

namespace KhaoSatBenhVien.ViewModels
{
    public class ChiTietPhieuDanhGiaViewModel
    {

        public int Id { get; set; }
        public int PhieuDanhGiaId { get; set; }
        public int CauHoiKhaoSatId { get; set; }
        public int MucDoHaiLongId { get; set; }

        public CauHoiKhaoSatViewModel CauHoiKhaoSat { get; set; }

        public MucDoHaiLongViewModel MucDoHaiLong { get; set; }


        public DateTime ThoiGianDanhGia { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }

    }
}
