﻿using AutoMapper;
using KhaoSatBenhVien.Models;
using KhaoSatBenhVien.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<ActionResult<IEnumerable<CanBoBenhVienViewModel>>> GetCanBoBenhViens()
        {
            var canBos = await _context.CanBoBenhViens.ToListAsync();
            var canBoViewModels = Mapper.Map<List<CanBoBenhVien>, List<CanBoBenhVienViewModel>>(canBos);

            foreach (var item in canBoViewModels)
            {
                var phanQuyen = _context.PhanQuyens.Where(x => x.CanBoBenhVienId == item.Id).ToList();
                item.PhanQuyens = new QuyenMapping();
                item.PhanQuyens.PhanQuyen = false;  
                item.PhanQuyens.QuanLyDanhMuc = false;
                item.PhanQuyens.BaoCao = false;
                item.PhanQuyens.CaNhan = false;
                if (phanQuyen.Count != 0)
                {
                    foreach (var quyen in phanQuyen)
                    {
                        if(quyen.QuyenId == 1)
                        {
                            item.PhanQuyens.PhanQuyen = true;
                           
                        }
                        if (quyen.QuyenId == 2)
                        {
                            item.PhanQuyens.QuanLyDanhMuc = true;

                        }

                        if (quyen.QuyenId == 3)
                        {
                            item.PhanQuyens.BaoCao = true;

                        }

                        if (quyen.QuyenId == 4)
                        {
                            item.PhanQuyens.CaNhan = true;
                        }
                    }
                }
            }

            foreach (var item in canBoViewModels)
            {
                var boPhan = _context.BoPhans.Where(x => x.Id == item.BoPhanId).FirstOrDefault();
                var boPhanView = Mapper.Map<BoPhan, BoPhanViewModel>(boPhan);
                item.BoPhan = boPhanView;
            }

            return canBoViewModels;
        }

        // GET: api/CanBoBenhViens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CanBoBenhVienViewModel>> GetCanBoBenhVien(int id)
        {
            var canBoBenhVien = await _context.CanBoBenhViens.FindAsync(id);
            var canBoViewModels = Mapper.Map<CanBoBenhVien, CanBoBenhVienViewModel>(canBoBenhVien);
            var phanQuyen = _context.PhanQuyens.Where(x => x.CanBoBenhVienId == canBoViewModels.Id).ToList();
            canBoViewModels.PhanQuyens = new QuyenMapping();
            canBoViewModels.PhanQuyens.PhanQuyen = false;
            canBoViewModels.PhanQuyens.QuanLyDanhMuc = false;
            canBoViewModels.PhanQuyens.BaoCao = false;
            canBoViewModels.PhanQuyens.CaNhan = false;
            if (phanQuyen.Count != 0)
            {
                foreach (var quyen in phanQuyen)
                {
                    if (quyen.QuyenId == 1)
                    {
                        canBoViewModels.PhanQuyens.PhanQuyen = true;

                    }
                    if (quyen.QuyenId == 2)
                    {
                        canBoViewModels.PhanQuyens.QuanLyDanhMuc = true;

                    }

                    if (quyen.QuyenId == 3)
                    {
                        canBoViewModels.PhanQuyens.BaoCao = true;

                    }

                    if (quyen.QuyenId == 4)
                    {
                        canBoViewModels.PhanQuyens.CaNhan = true;
                    }
                }
            }
            return canBoViewModels;
        }

        // PUT: api/CanBoBenhViens/5

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
