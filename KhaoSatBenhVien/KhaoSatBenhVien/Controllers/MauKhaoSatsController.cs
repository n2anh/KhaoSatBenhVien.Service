using KhaoSatBenhVien.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhaoSatBenhVien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MauKhaoSatsController : ControllerBase
    {
        private readonly KhaoSatDbContext _context;

        public MauKhaoSatsController(KhaoSatDbContext context)
        {
            _context = context;
        }

        // GET: api/MauKhaoSats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MauKhaoSat>>> GetMauKhaoSat()
        {
            return await _context.MauKhaoSat.ToListAsync();
        }

        // GET: api/MauKhaoSats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MauKhaoSat>> GetMauKhaoSat(int id)
        {
            var mauKhaoSat = await _context.MauKhaoSat.FindAsync(id);

            if (mauKhaoSat == null)
            {
                return NotFound();
            }

            return mauKhaoSat;
        }

        // PUT: api/MauKhaoSats/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMauKhaoSat(int id, MauKhaoSat mauKhaoSat)
        {
            if (id != mauKhaoSat.Id)
            {
                return BadRequest();
            }

            _context.Entry(mauKhaoSat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MauKhaoSatExists(id))
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

        // POST: api/MauKhaoSats
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MauKhaoSat>> PostMauKhaoSat(MauKhaoSat mauKhaoSat)
        {
            _context.MauKhaoSat.Add(mauKhaoSat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMauKhaoSat", new { id = mauKhaoSat.Id }, mauKhaoSat);
        }

        // DELETE: api/MauKhaoSats/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MauKhaoSat>> DeleteMauKhaoSat(int id)
        {
            var mauKhaoSat = await _context.MauKhaoSat.FindAsync(id);
            if (mauKhaoSat == null)
            {
                return NotFound();
            }

            _context.MauKhaoSat.Remove(mauKhaoSat);
            await _context.SaveChangesAsync();

            return mauKhaoSat;
        }

        private bool MauKhaoSatExists(int id)
        {
            return _context.MauKhaoSat.Any(e => e.Id == id);
        }
    }
}
