using AutoMapper;
using KhaoSatBenhVien.Models;
using KhaoSatBenhVien.ViewModels;
using KhaoSatBenhVien.Views;
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



        [HttpPost("bao-cao-theo-tung-phong-ban")]
        public object BaoCaoBoPhan_DK(DK_BaoCao_BoPhan_MucDoHaiLong dieuKien)
        {
            try
            {
                List<BoPhanReport> boPhanReports = new List<BoPhanReport>();

                var boPhans = _context.BoPhans.ToList();

                if(dieuKien.BoPhanId != null)
                {
                    boPhans = boPhans.Where(x => x.Id == dieuKien.BoPhanId).ToList();
                }
             
                var boPhanView = Mapper.Map<List<BoPhan>, List<BoPhanViewModel>>(boPhans);

                var mucDoHaiLongs = _context.MucDoHaiLongs.ToList();

                foreach (var item in boPhanView)
                {
                    
                    BoPhanReport boPhanReport = new BoPhanReport { BoPhanViewModel = item, CommonObjects = new List<CommonObject>() };
                    foreach (var m in mucDoHaiLongs)
                    {
                        CommonObject commonObject = new CommonObject();
                        commonObject.Name = m.NoiDung;
                        commonObject.Value = 0;
                        boPhanReport.CommonObjects.Add(commonObject);
                    }
                    boPhanReports.Add(boPhanReport);
                }

                foreach (var item in boPhanReports)
                {
                    foreach (var i in item.CommonObjects)
                    {
                        

                        var temp = (from b in _context.BoPhans
                                    join p in _context.PhieuDanhGias on b.Id equals p.BoPhanId
                                    join ctp in _context.ChiTietPhieuDanhGias on p.Id equals ctp.PhieuDanhGiaId
                                    join md in _context.MucDoHaiLongs on ctp.MucDoHaiLongId equals md.Id
                                    where p.BoPhanId == item.BoPhanViewModel.Id && i.Name == md.NoiDung
                                    select new
                                    {
                                        b.Id,
                                        MucDoID = md.Id,
                                        ChiTietPhieuId = ctp.Id, 
                                        NgayTaoPhieu = p.NgayTao
                                    }).ToList();

                        if(dieuKien.TuNgay != null && dieuKien.DenNgay != null)
                        {
                            temp = temp.Where(x => x.NgayTaoPhieu.Value.Date >= dieuKien.TuNgay.Value.Date && x.NgayTaoPhieu.Value.Date <= dieuKien.DenNgay.Value.Date).ToList();
                        }

                        i.Value = temp.Count;
                    }
                }




                return boPhanReports;
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest("Lỗi không xác định!");

            }



        
        }
    }
}