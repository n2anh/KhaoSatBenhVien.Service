using AutoMapper;
using KhaoSatBenhVien.Models;
using KhaoSatBenhVien.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhaoSatBenhVien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhieuDanhGiasController : ControllerBase
    {
        private readonly KhaoSatDbContext _context;

        public PhieuDanhGiasController(KhaoSatDbContext context)
        {
            _context = context;
        }

        // GET: api/PhieuDanhGias
        [HttpPost("get-condition")]
        public  ActionResult<List<PhieuDanhGiasViewModel>> GetPhieuDanhGias(DieuKienPhieuKhaoSat dieuKien)
        {
            var phieuKhaoSats = _context.PhieuDanhGias.ToList();
            var phieuKhaoSatViewModel = Mapper.Map<List<PhieuDanhGia>, List<PhieuDanhGiasViewModel>>(phieuKhaoSats);
            
            if(dieuKien.TuNgay != null)
            {
                if (dieuKien.TuNgay < dieuKien.DenNgay)
                {
                    phieuKhaoSatViewModel = phieuKhaoSatViewModel.Where(x => x.NgayTao.Value.Date >= dieuKien.TuNgay.Value.Date && x.NgayTao.Value.Date <= dieuKien.DenNgay.Value.Date).ToList();
                }
                else
                {
                    return BadRequest("Lỗi ngày bắt đầu, kết thúc không hợp lệ!");
                }
            }


            if (dieuKien.BoPhanId != null)
            {
                phieuKhaoSatViewModel = phieuKhaoSatViewModel.Where(x => x.Id == dieuKien.BoPhanId).ToList();
            }


            if(dieuKien.BenhNhanId != null)
            {
                phieuKhaoSatViewModel = phieuKhaoSatViewModel.Where(x => x.BenhNhanId == dieuKien.BenhNhanId).ToList();
            }


            foreach (var item in phieuKhaoSatViewModel)
            {
                var boPhan = _context.BoPhans.Where(x => x.Id == item.BoPhanId).FirstOrDefault();
                var boPhanView = Mapper.Map<BoPhan, BoPhanViewModel>(boPhan);

                var benhNhan = _context.BenhNhans.Where(x => x.Id == item.BenhNhanId).FirstOrDefault();
                var benhNhanView = Mapper.Map<BenhNhan, BenhNhanViewModel>(benhNhan);
                item.BoPhan = boPhanView;

                item.BenhNhan = benhNhanView;
            }

            return phieuKhaoSatViewModel;

        }

        // GET: api/PhieuDanhGias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhieuDanhGia>> GetPhieuDanhGia(int id)
        {
            var phieuDanhGia = await _context.PhieuDanhGias.FindAsync(id);

            if (phieuDanhGia == null)
            {
                return NotFound();
            }

            return phieuDanhGia;
        }

        // PUT: api/PhieuDanhGias/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhieuDanhGia(int id, PhieuDanhGia phieuDanhGia)
        {
            if (id != phieuDanhGia.Id)
            {
                return BadRequest();
            }
            phieuDanhGia.NgayCapNhat = DateTime.Now;

            _context.Entry(phieuDanhGia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhieuDanhGiaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PhieuDanhGias
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PhieuDanhGiasViewModel>> PostPhieuDanhGia(PhieuDanhGiasViewModel phieuDanhGiaView)
        {
            var phieuDanhGia = Mapper.Map<PhieuDanhGiasViewModel, PhieuDanhGia>(phieuDanhGiaView);

            phieuDanhGia.NgayTao = DateTime.Now;

            _context.PhieuDanhGias.Add(phieuDanhGia);

            _context.SaveChanges();

            phieuDanhGia = _context.PhieuDanhGias.Where(x => x.BenhNhanId == phieuDanhGiaView.BenhNhanId && x.BoPhanId == phieuDanhGiaView.BoPhanId)
                .OrderByDescending(x => x.NgayTao).ToList()[0];

            var chiTietPhieus = Mapper.Map<List<ChiTietPhieuDanhGiaViewModel>, List<ChiTietPhieuDanhGia>>(phieuDanhGiaView.chiTietPhieuDanhs);

            foreach (var item in chiTietPhieus)
            {
                item.PhieuDanhGiaId = phieuDanhGia.Id;
                item.NgayTao = DateTime.Now;
            }

            _context.ChiTietPhieuDanhGias.AddRange(chiTietPhieus);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhieuDanhGia", new { id = phieuDanhGia.Id }, phieuDanhGiaView);
        }

        // DELETE: api/PhieuDanhGias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PhieuDanhGia>> DeletePhieuDanhGia(int id)
        {
            var phieuDanhGia = await _context.PhieuDanhGias.FindAsync(id);
            if (phieuDanhGia == null)
            {
                return NotFound();
            }

            _context.PhieuDanhGias.Remove(phieuDanhGia);
            await _context.SaveChangesAsync();

            return phieuDanhGia;
        }

        private bool PhieuDanhGiaExists(int id)
        {
            return _context.PhieuDanhGias.Any(e => e.Id == id);
        }
    }
}
