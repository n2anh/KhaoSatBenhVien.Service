using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhaoSatBenhVien.ViewModels
{
    public class ChiTietPhieuDanhGiaViewModel
    {

        public int Id { get; set; }
        public int PhieuDanhGiaId { get; set; }
        public int CauHoiKhaoSatId { get; set; }
        public int MucDoHaiLongId { get; set; }

        public DateTime ThoiGianDanhGia { get; set; }

    }
}
