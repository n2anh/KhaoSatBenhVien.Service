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
    public class BenhNhansController : ControllerBase
    {
        private readonly KhaoSatDbContext _context;

        public BenhNhansController(KhaoSatDbContext context)
        {
            _context = context;
        }

        // GET: api/BenhNhans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BenhNhan>>> GetBenhNhans()
        {
            return await _context.BenhNhans.ToListAsync();
        }

        // GET: api/BenhNhans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BenhNhan>> GetBenhNhan(int id)
        {
            var benhNhan = await _context.BenhNhans.FindAsync(id);

            if (benhNhan == null)
            {
                return NotFound();
            }

            return benhNhan;
        }

        // PUT: api/BenhNhans/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBenhNhan(int id, BenhNhan benhNhan)
        {
            if (id != benhNhan.Id)
            {
                return BadRequest();
            }

            _context.Entry(benhNhan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BenhNhanExists(id))
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

        // POST: api/BenhNhans
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BenhNhan>> PostBenhNhan(BenhNhan benhNhan)
        {
            _context.BenhNhans.Add(benhNhan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBenhNhan", new { id = benhNhan.Id }, benhNhan);
        }

        // DELETE: api/BenhNhans/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BenhNhan>> DeleteBenhNhan(int id)
        {
            var benhNhan = await _context.BenhNhans.FindAsync(id);
            if (benhNhan == null)
            {
                return NotFound();
            }

            _context.BenhNhans.Remove(benhNhan);
            await _context.SaveChangesAsync();

            return benhNhan;
        }

        private bool BenhNhanExists(int id)
        {
            return _context.BenhNhans.Any(e => e.Id == id);
        }
    }
}
