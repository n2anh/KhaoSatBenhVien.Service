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
    public class MucDoHaiLongsController : ControllerBase
    {
        private readonly KhaoSatDbContext _context;

        public MucDoHaiLongsController(KhaoSatDbContext context)
        {
            _context = context;
        }

        // GET: api/MucDoHaiLongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MucDoHaiLong>>> GetMucDoHaiLongs()
        {
            return await _context.MucDoHaiLongs.ToListAsync();
        }

        // GET: api/MucDoHaiLongs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MucDoHaiLong>> GetMucDoHaiLong(int id)
        {
            var mucDoHaiLong = await _context.MucDoHaiLongs.FindAsync(id);

            if (mucDoHaiLong == null)
            {
                return NotFound();
            }

            return mucDoHaiLong;
        }

        // PUT: api/MucDoHaiLongs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMucDoHaiLong(int id, MucDoHaiLong mucDoHaiLong)
        {
            if (id != mucDoHaiLong.Id)
            {
                return BadRequest();
            }

            _context.Entry(mucDoHaiLong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MucDoHaiLongExists(id))
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

        // POST: api/MucDoHaiLongs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MucDoHaiLong>> PostMucDoHaiLong(MucDoHaiLong mucDoHaiLong)
        {
            _context.MucDoHaiLongs.Add(mucDoHaiLong);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMucDoHaiLong", new { id = mucDoHaiLong.Id }, mucDoHaiLong);
        }

        // DELETE: api/MucDoHaiLongs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MucDoHaiLong>> DeleteMucDoHaiLong(int id)
        {
            var mucDoHaiLong = await _context.MucDoHaiLongs.FindAsync(id);
            if (mucDoHaiLong == null)
            {
                return NotFound();
            }

            _context.MucDoHaiLongs.Remove(mucDoHaiLong);
            await _context.SaveChangesAsync();

            return mucDoHaiLong;
        }

        private bool MucDoHaiLongExists(int id)
        {
            return _context.MucDoHaiLongs.Any(e => e.Id == id);
        }
    }
}
