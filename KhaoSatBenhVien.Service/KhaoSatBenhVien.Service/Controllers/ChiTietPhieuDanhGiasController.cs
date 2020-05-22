using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KhaoSatBenhVien.Service;
using KhaoSatBenhVien.Service.Models;

namespace KhaoSatBenhVien.Service.Controllers
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

        // GET: api/ChiTietPhieuDanhGias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChiTietPhieuDanhGia>> GetChiTietPhieuDanhGia(int id)
        {
            var chiTietPhieuDanhGia = await _context.ChiTietPhieuDanhGias.FindAsync(id);

            if (chiTietPhieuDanhGia == null)
            {
                return NotFound();
            }

            return chiTietPhieuDanhGia;
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
