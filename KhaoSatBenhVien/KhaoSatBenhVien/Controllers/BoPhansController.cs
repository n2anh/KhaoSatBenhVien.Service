using AutoMapper;
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
    public class BoPhansController : ControllerBase
    {
        private readonly KhaoSatDbContext _context;

        public BoPhansController(KhaoSatDbContext context)
        {
            _context = context;
        }

        // GET: api/BoPhans
        [HttpGet]
        public ActionResult<IEnumerable<BoPhanViewModel>> GetBoPhans()
        {
            var bophans = _context.BoPhans.ToList();
        
            var boPhanViews = Mapper.Map<List<BoPhan>, List<BoPhanViewModel>>(bophans);
            foreach (var item in boPhanViews)
            {
                var boPhanCha = _context.BoPhans.Where(x => x.Id == item.BoPhanId).FirstOrDefault();
                if(boPhanCha != null)
                {
                    var boPhanChaViewModel = Mapper.Map<BoPhan, BoPhanViewModel>(boPhanCha);
                    item.BoPhanCha = boPhanChaViewModel;
                }
            }
            return boPhanViews;
        }

        // GET: api/BoPhans/5
        [HttpGet("{id}")]
        public ActionResult<BoPhanViewModel> GetBoPhan(int id)
        {
            var bophans = _context.BoPhans.Where(x => x.Id == id).FirstOrDefault();

            var boPhanViews = Mapper.Map<BoPhan, BoPhanViewModel>(bophans);
            var boPhanCha = _context.BoPhans.Where(x => x.Id == boPhanViews.BoPhanId).FirstOrDefault();
            var boPhanChaViewModel = Mapper.Map<BoPhan, BoPhanViewModel>(boPhanCha);
            boPhanViews.BoPhanCha = boPhanChaViewModel;
            if (boPhanViews == null)
            {
                return NotFound();
            }

            return boPhanViews;
        }

        // PUT: api/BoPhans/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoPhan(int id, BoPhanViewModel boPhan)
        {
            if (id != boPhan.Id)
            {
                return BadRequest();
            }

            var boPhanV = Mapper.Map<BoPhanViewModel, BoPhan>(boPhan);

            try
            {
                _context.Update(boPhanV);
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
        [HttpPost]
        public async Task<ActionResult<BoPhan>> PostBoPhan(BoPhanViewModel boPhanViewModel)
        {
            var boPhan = Mapper.Map<BoPhanViewModel, BoPhan>(boPhanViewModel);
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
