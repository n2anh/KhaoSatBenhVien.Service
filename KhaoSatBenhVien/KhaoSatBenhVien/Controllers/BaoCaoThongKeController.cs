using KhaoSatBenhVien.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace KhaoSatBenhVien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaoCaoThongKeController : ControllerBase
    {
        private readonly KhaoSatDbContext _context;

        public BaoCaoThongKeController(KhaoSatDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public object PostBenhNhan(DK_BaoCao_BoPhan_MucDoHaiLong dieuKien)
        {
            try
            {
                var temp = from b in _context.BoPhans
                            join p in _context.PhieuDanhGias on b.Id equals p.BoPhanId
                            join ctp in _context.ChiTietPhieuDanhGias on p.Id equals ctp.PhieuDanhGiaId
                            select new
                            {
                                b.Id,
                                b.TenBoPhan,
                                ctp.MucDoHaiLongId,
                                p.NgayTao
                            };

                var boPhanMucDos = (from m in _context.MucDoHaiLongs
                                    join t in temp on m.Id equals t.MucDoHaiLongId into mucDo
                                    from x in mucDo.DefaultIfEmpty()
                                    select new
                                    {
                                        MucDoHaiLongId = m.Id,
                                        x.Id,
                                        x.NgayTao,
                                        x.TenBoPhan,
                                        m.Logo,
                                        m.NoiDung
                                    }).ToList();



                if (dieuKien.TuNgay != null && dieuKien.DenNgay != null)
                {
                    if(dieuKien.TuNgay < dieuKien.DenNgay)
                    {
                        boPhanMucDos = boPhanMucDos.Where(x => x.NgayTao >= dieuKien.TuNgay && x.NgayTao <= dieuKien.DenNgay).ToList();
                    }
                    else
                    {
                        return BadRequest("Lỗi ngày bắt đầu, kết thúc không hợp lệ!");
                    }
                }

                if(dieuKien.BoPhanId !=null)
                {
                    boPhanMucDos = boPhanMucDos.Where(x => x.Id == dieuKien.BoPhanId).ToList();
                }

                var boPhans = _context.BoPhans;

                var mucDoHaiLongs = _context.MucDoHaiLongs;

                var result = new List<object>();

                foreach (var boPhan in boPhans)
                {
                    var records = boPhanMucDos.Where(x => x.Id == boPhan.Id).ToList();

    
                    var MDHL_BP = (from r in records
                                   group r by r.MucDoHaiLongId into x
                                   select new
                                   {
                                       MucDoHaiLongId = x.Key,
                                       SoLuong = (x == null)?0: x.Count() 
                                   }).ToList();

                    result.Add(new {
                       BoPhan = boPhan,
                       KetQua = MDHL_BP
                    });
                }

                return result;
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest("Lỗi không xác định!");

            }
           
            
        }
    }
}