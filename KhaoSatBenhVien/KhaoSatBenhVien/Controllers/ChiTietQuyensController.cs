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
    public class ChiTietQuyensController : ControllerBase
    {
        private readonly KhaoSatDbContext _context;

        public ChiTietQuyensController(KhaoSatDbContext context)
        {
            _context = context;
        }

        // GET: api/ChiTietQuyens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietQuyen>>> GetChiTietQuyens()
        {
            return await _context.ChiTietQuyens.ToListAsync();
        }

        // GET: api/ChiTietQuyens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChiTietQuyen>> GetChiTietQuyen(int id)
        {
            var chiTietQuyen = await _context.ChiTietQuyens.FindAsync(id);

            if (chiTietQuyen == null)
            {
                return NotFound();
            }

            return chiTietQuyen;
        }

        // PUT: api/ChiTietQuyens/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChiTietQuyen(int id, ChiTietQuyen chiTietQuyen)
        {
            if (id != chiTietQuyen.Id)
            {
                return BadRequest();
            }

            _context.Entry(chiTietQuyen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietQuyenExists(id))
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

        // POST: api/ChiTietQuyens
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ChiTietQuyen>> PostChiTietQuyen(ChiTietQuyen chiTietQuyen)
        {
            _context.ChiTietQuyens.Add(chiTietQuyen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChiTietQuyen", new { id = chiTietQuyen.Id }, chiTietQuyen);
        }

        // DELETE: api/ChiTietQuyens/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ChiTietQuyen>> DeleteChiTietQuyen(int id)
        {
            var chiTietQuyen = await _context.ChiTietQuyens.FindAsync(id);
            if (chiTietQuyen == null)
            {
                return NotFound();
            }

            _context.ChiTietQuyens.Remove(chiTietQuyen);
            await _context.SaveChangesAsync();

            return chiTietQuyen;
        }

        private bool ChiTietQuyenExists(int id)
        {
            return _context.ChiTietQuyens.Any(e => e.Id == id);
        }
    }
}
