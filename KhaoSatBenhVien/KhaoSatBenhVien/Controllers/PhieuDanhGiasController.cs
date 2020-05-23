using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KhaoSatBenhVien;
using KhaoSatBenhVien.Models;

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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhieuDanhGia>>> GetPhieuDanhGias()
        {
            return await _context.PhieuDanhGias.ToListAsync();
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
        public async Task<ActionResult<PhieuDanhGia>> PostPhieuDanhGia(PhieuDanhGia phieuDanhGia)
        {
            _context.PhieuDanhGias.Add(phieuDanhGia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhieuDanhGia", new { id = phieuDanhGia.Id }, phieuDanhGia);
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
