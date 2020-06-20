using AutoMapper;
using KhaoSatBenhVien.Models;
using KhaoSatBenhVien.Models.Enums;
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
    public class CauHoiKhaoSatsController : ControllerBase
    {
        private readonly KhaoSatDbContext _context;

        public CauHoiKhaoSatsController(KhaoSatDbContext context)
        {
            _context = context;
        }

        // GET: api/CauHoiKhaoSats
        [HttpGet]
        public List<CauHoiKhaoSatViewModel> GetCauHoiKhaoSats()
        {
            var cauHois = _context.CauHoiKhaoSats.ToList();

          
            var cauHoisViewModel = Mapper.Map<List<CauHoiKhaoSat>, List<CauHoiKhaoSatViewModel>>(cauHois);

            foreach (var item in cauHoisViewModel)
            {
                var mauKhao = _context.MauKhaoSat.Where(x => x.Id == item.MauKhaoSatId).FirstOrDefault();
                var mauKhaoViewModel = Mapper.Map<MauKhaoSat, MauKhaoSatViewModel>(mauKhao);
                if (mauKhao != null)
                {
                    item.MauKhaoSatViewModel = mauKhaoViewModel;
                }
            }

            return cauHoisViewModel;
        }



        // GET: api/CauHoiKhaoSats
        [HttpGet("cau-hoi-khao-sat/{mauCauHoiId}")]
        public  ActionResult<List<CauHoiKhaoSatViewModel>> GetCauHoiKhaoSatsByMauCauHoi(int? mauCauHoiId)
        {
         
          
            var cauHois = _context.CauHoiKhaoSats.Where(x => x.TrangThai == Status.Active).ToList();

            if (null != mauCauHoiId)
            {
                cauHois = cauHois.Where(x => mauCauHoiId == x.MauKhaoSatId).ToList();
            }


            var cauHoisViewModel = Mapper.Map<List<CauHoiKhaoSat>, List<CauHoiKhaoSatViewModel>>(cauHois);

            foreach (var item in cauHoisViewModel)
            {
                var mauKhao = _context.MauKhaoSat.Where(x => x.Id == item.MauKhaoSatId).FirstOrDefault();
                var mauKhaoViewModel = Mapper.Map<MauKhaoSat, MauKhaoSatViewModel>(mauKhao);
                if (mauKhao != null)
                {
                    item.MauKhaoSatViewModel = mauKhaoViewModel;
                }
            }

            return cauHoisViewModel;
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
        [HttpPost]
        public async Task<ActionResult<CauHoiKhaoSat>> PostCauHoiKhaoSat(CauHoiKhaoSat cauHoiKhaoSat)
        {
            cauHoiKhaoSat.TrangThai = Status.Active;
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
