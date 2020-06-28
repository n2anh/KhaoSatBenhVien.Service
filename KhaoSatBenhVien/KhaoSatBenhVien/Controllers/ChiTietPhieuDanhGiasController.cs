using AutoMapper;
using KhaoSatBenhVien.Models;
using KhaoSatBenhVien.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhaoSatBenhVien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietPhieuDanhGiasController : ControllerBase
    {
        private readonly KhaoSatDbContext _context;

        public ChiTietPhieuDanhGiasController(KhaoSatDbContext context)
        {
            _context = context;
        }

        // GET: api/ChiTietPhieuDanhGias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietPhieuDanhGia>>> GetChiTietPhieuDanhGias()
        {
            return await _context.ChiTietPhieuDanhGias.ToListAsync();
        }

        // GET: api/ChiTietPhieuDanhGias
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ChiTietPhieuDanhGiaViewModel>>> GetChiTietPhieuDanhGiasById(int id)
        {
            var chiTiet = await _context.ChiTietPhieuDanhGias.Where(x => x.PhieuDanhGiaId == id).ToListAsync();
            var chiTietView = Mapper.Map<List<ChiTietPhieuDanhGia>, List<ChiTietPhieuDanhGiaViewModel>>(chiTiet);

            foreach (var chi in chiTietView)
            {
                var mucDo = _context.MucDoHaiLongs.Where(x => x.Id == chi.MucDoHaiLongId).FirstOrDefault();
                var mucDoView = Mapper.Map<MucDoHaiLong, MucDoHaiLongViewModel>(mucDo);
                chi.MucDoHaiLong = mucDoView;
                var cauHoi = _context.CauHoiKhaoSats.Where(x => x.Id == chi.CauHoiKhaoSatId).FirstOrDefault();
                var cauHoiView = Mapper.Map<CauHoiKhaoSat, CauHoiKhaoSatViewModel>(cauHoi);
                chi.CauHoiKhaoSat = cauHoiView;

            }
            return chiTietView;
        }




        // PUT: api/ChiTietPhieuDanhGias/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChiTietPhieuDanhGia(int id, ChiTietPhieuDanhGia chiTietPhieuDanhGia)
        {
            if (id != chiTietPhieuDanhGia.Id)
            {
                return BadRequest();
            }

            _context.Entry(chiTietPhieuDanhGia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietPhieuDanhGiaExists(id))
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

        // POST: api/ChiTietPhieuDanhGias
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ChiTietPhieuDanhGia>> PostChiTietPhieuDanhGia(ChiTietPhieuDanhGia chiTietPhieuDanhGia)
        {
            _context.ChiTietPhieuDanhGias.Add(chiTietPhieuDanhGia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChiTietPhieuDanhGia", new { id = chiTietPhieuDanhGia.Id }, chiTietPhieuDanhGia);
        }

        // DELETE: api/ChiTietPhieuDanhGias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ChiTietPhieuDanhGia>> DeleteChiTietPhieuDanhGia(int id)
        {
            var chiTietPhieuDanhGia = await _context.ChiTietPhieuDanhGias.FindAsync(id);
            if (chiTietPhieuDanhGia == null)
            {
                return NotFound();
            }

            _context.ChiTietPhieuDanhGias.Remove(chiTietPhieuDanhGia);
            await _context.SaveChangesAsync();

            return chiTietPhieuDanhGia;
        }

        private bool ChiTietPhieuDanhGiaExists(int id)
        {
            return _context.ChiTietPhieuDanhGias.Any(e => e.Id == id);
        }
    }
}
