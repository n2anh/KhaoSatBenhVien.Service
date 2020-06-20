using System.Collections.Generic;

namespace KhaoSatBenhVien.ViewModels
{
    public class MauKhaoSatViewModel
    {
       
        public int Id { get; set; }

        public string TenMauKhaoSat { get; set; }

        public List<CauHoiKhaoSatViewModel> CauHoiKhaoSatsViewModel { get; set; }
    }
}
