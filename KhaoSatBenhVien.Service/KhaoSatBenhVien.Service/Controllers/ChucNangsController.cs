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
    public class ChucNangsController : ControllerBase
    {
        private readonly KhaoSatDbContext _context;

        public ChucNangsController(KhaoSatDbContext context)
        {
            _context = context;
        }

        // GET: api/ChucNangs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChucNang>>> GetChucNangs()
        {
            return await _context.ChucNangs.ToListAsync();
        }

        // GET: api/ChucNangs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChucNang>> GetChucNang(int id)
        {
            var chucNang = await _context.ChucNangs.FindAsync(id);

            if (chucNang == null)
            {
                return NotFound();
            }

            return chucNang;
        }

        // PUT: api/ChucNangs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChucNang(int id, ChucNang chucNang)
        {
            if (id != chucNang.Id)
            {
                return BadRequest();
            }

            _context.Entry(chucNang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChucNangExists(id))
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

        // POST: api/ChucNangs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ChucNang>> PostChucNang(ChucNang chucNang)
        {
            _context.ChucNangs.Add(chucNang);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChucNang", new { id = chucNang.Id }, chucNang);
        }

        // DELETE: api/ChucNangs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ChucNang>> DeleteChucNang(int id)
        {
            var chucNang = await _context.ChucNangs.FindAsync(id);
            if (chucNang == null)
            {
                return NotFound();
            }

            _context.ChucNangs.Remove(chucNang);
            await _context.SaveChangesAsync();

            return chucNang;
        }

        private bool ChucNangExists(int id)
        {
            return _context.ChucNangs.Any(e => e.Id == id);
        }
    }
}
