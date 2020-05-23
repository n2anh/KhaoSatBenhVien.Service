﻿using System;
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
    public class CanBoBenhViensController : ControllerBase
    {
        private readonly KhaoSatDbContext _context;

        public CanBoBenhViensController(KhaoSatDbContext context)
        {
            _context = context;
        }

        // GET: api/CanBoBenhViens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CanBoBenhVien>>> GetCanBoBenhViens()
        {
            return await _context.CanBoBenhViens.ToListAsync();
        }

        // GET: api/CanBoBenhViens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CanBoBenhVien>> GetCanBoBenhVien(int id)
        {
            var canBoBenhVien = await _context.CanBoBenhViens.FindAsync(id);

            if (canBoBenhVien == null)
            {
                return NotFound();
            }

            return canBoBenhVien;
        }

        // PUT: api/CanBoBenhViens/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCanBoBenhVien(int id, CanBoBenhVien canBoBenhVien)
        {
            if (id != canBoBenhVien.Id)
            {
                return BadRequest();
            }

            _context.Entry(canBoBenhVien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CanBoBenhVienExists(id))
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

        // POST: api/CanBoBenhViens
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CanBoBenhVien>> PostCanBoBenhVien(CanBoBenhVien canBoBenhVien)
        {
            _context.CanBoBenhViens.Add(canBoBenhVien);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCanBoBenhVien", new { id = canBoBenhVien.Id }, canBoBenhVien);
        }

        // DELETE: api/CanBoBenhViens/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CanBoBenhVien>> DeleteCanBoBenhVien(int id)
        {
            var canBoBenhVien = await _context.CanBoBenhViens.FindAsync(id);
            if (canBoBenhVien == null)
            {
                return NotFound();
            }

            _context.CanBoBenhViens.Remove(canBoBenhVien);
            await _context.SaveChangesAsync();

            return canBoBenhVien;
        }

        private bool CanBoBenhVienExists(int id)
        {
            return _context.CanBoBenhViens.Any(e => e.Id == id);
        }
    }
}