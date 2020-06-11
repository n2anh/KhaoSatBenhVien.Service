using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhaoSatBenhVien.ViewModels
{
    public class BoPhanViewModel
    {
     
        public int Id { get; set; }

       
        public string TenBoPhan { get; set; }



       
        public string DiaDiem { get; set; }


   
        public string Logo { get; set; }


     
        public string LoiChao { get; set; }

        public string AnhNen { get; set; }

        public string ThongTinMoTa { get; set; }



       
        public string LichLamViec { get; set; }



        public DateTime? NgayTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }
    }
}
