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
    public class BoPhansController : ControllerBase
    {
        private readonly KhaoSatDbContext _context;

        public BoPhansController(KhaoSatDbContext context)
        {
            _context = context;
        }

        // GET: api/BoPhans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoPhan>>> GetBoPhans()
        {
            return await _context.BoPhans.ToListAsync();
        }

        // GET: api/BoPhans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BoPhan>> GetBoPhan(int id)
        {
            var boPhan = await _context.BoPhans.FindAsync(id);

            if (boPhan == null)
            {
                return NotFound();
            }

            return boPhan;
        }

        // PUT: api/BoPhans/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoPhan(int id, BoPhan boPhan)
        {
            if (id != boPhan.Id)
            {
                return BadRequest();
            }

            _context.Entry(boPhan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoPhanExists(id))
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

        // POST: api/BoPhans
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BoPhan>> PostBoPhan(BoPhan boPhan)
        {
            _context.BoPhans.Add(boPhan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoPhan", new { id = boPhan.Id }, boPhan);
        }

        // DELETE: api/BoPhans/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BoPhan>> DeleteBoPhan(int id)
        {
            var boPhan = await _context.BoPhans.FindAsync(id);
            if (boPhan == null)
            {
                return NotFound();
            }

            _context.BoPhans.Remove(boPhan);
            await _context.SaveChangesAsync();

            return boPhan;
        }

        private bool BoPhanExists(int id)
        {
            return _context.BoPhans.Any(e => e.Id == id);
        }
    }
}
