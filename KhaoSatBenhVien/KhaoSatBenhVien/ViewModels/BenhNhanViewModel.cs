using System;
using System.Collections.Generic;

namespace KhaoSatBenhVien.ViewModels
{
    public class BenhNhanViewModel
    {
      
        public int Id { get; set; }

      
        public string TenBenhNhan { get; set; }

     
        public string CMTND { get; set; }

        List<PhieuDanhGiasViewModel> PhieuDanhGias { get; set; }


        public DateTime? NgayTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }
    }
}
