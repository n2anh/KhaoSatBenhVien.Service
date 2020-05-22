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
    public class CauHoiKhaoSatsController : ControllerBase
    {
        private readonly KhaoSatDbContext _context;

        public CauHoiKhaoSatsController(KhaoSatDbContext context)
        {
            _context = context;
        }

        // GET: api/CauHoiKhaoSats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CauHoiKhaoSat>>> GetCauHoiKhaoSats()
        {
            return await _context.CauHoiKhaoSats.ToListAsync();
        }

        // GET: api/CauHoiKhaoSats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CauHoiKhaoSat>> GetCauHoiKhaoSat(int id)
        {
            var cauHoiKhaoSat = await _context.CauHoiKhaoSats.FindAsync(id);

            if (cauHoiKhaoSat == null)
            {
                return NotFound();
            }

            return cauHoiKhaoSat;
        }

        // PUT: api/CauHoiKhaoSats/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCauHoiKhaoSat(int id, CauHoiKhaoSat cauHoiKhaoSat)
        {
            if (id != cauHoiKhaoSat.Id)
            {
                return BadRequest();
            }

            _context.Entry(cauHoiKhaoSat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CauHoiKhaoSatExists(id))
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

        // POST: api/CauHoiKhaoSats
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CauHoiKhaoSat>> PostCauHoiKhaoSat(CauHoiKhaoSat cauHoiKhaoSat)
        {
            _context.CauHoiKhaoSats.Add(cauHoiKhaoSat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCauHoiKhaoSat", new { id = cauHoiKhaoSat.Id }, cauHoiKhaoSat);
        }

        // DELETE: api/CauHoiKhaoSats/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CauHoiKhaoSat>> DeleteCauHoiKhaoSat(int id)
        {
            var cauHoiKhaoSat = await _context.CauHoiKhaoSats.FindAsync(id);
            if (cauHoiKhaoSat == null)
            {
                return NotFound();
            }

            _context.CauHoiKhaoSats.Remove(cauHoiKhaoSat);
            await _context.SaveChangesAsync();

            return cauHoiKhaoSat;
        }

        private bool CauHoiKhaoSatExists(int id)
        {
            return _context.CauHoiKhaoSats.Any(e => e.Id == id);
        }
    }
}
