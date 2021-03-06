﻿using KhaoSatBenhVien.Models;
using System;
using System.Collections.Generic;

namespace KhaoSatBenhVien.ViewModels
{
    public class PhieuDanhGiasViewModel
    {
        public int Id { get; set; }

        public int BenhNhanId { get; set; }

        public int BoPhanId { get; set; }

        public BenhNhanViewModel BenhNhan { get; set; }

        public BoPhanViewModel BoPhan { get; set; }


        public DateTime ThoiGianBatDau { get; set; }

        public DateTime ThoiGianKetThuc { get; set; }

        public string NoiDungDanhGiaKhac { get; set; }

        public string AnhDanhGiaKhac { get; set; }

        public List<ChiTietPhieuDanhGiaViewModel> chiTietPhieuDanhs { get; set; }

        public DateTime? NgayTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }
    }
}
