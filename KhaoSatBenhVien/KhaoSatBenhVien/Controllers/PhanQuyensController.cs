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
    public class PhanQuyensController : ControllerBase
    {
        private readonly KhaoSatDbContext _context;

        public PhanQuyensController(KhaoSatDbContext context)
        {
            _context = context;
        }

        // GET: api/PhanQuyens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhanQuyen>>> GetPhanQuyens()
        {
            return await _context.PhanQuyens.ToListAsync();
        }

        // GET: api/PhanQuyens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhanQuyen>> GetPhanQuyen(int id)
        {
            var phanQuyen = await _context.PhanQuyens.FindAsync(id);

            if (phanQuyen == null)
            {
                return NotFound();
            }

            return phanQuyen;
        }

        // POST: api/PhanQuyens
        [HttpPost]
        public  ActionResult<object> PostPhanQuyen(CanBoBenhVienViewModel canBo)
        {
            var deleteList = _context.PhanQuyens.Where(x => x.CanBoBenhVienId == canBo.Id).ToList();
            _context.PhanQuyens.RemoveRange(deleteList);
            _context.SaveChanges();

          
            if (canBo.PhanQuyens.PhanQuyen == true)
            {
                var phan = new PhanQuyen();
                phan.CanBoBenhVienId = canBo.Id;
                phan.QuyenId = 1;
                _context.PhanQuyens.Add(phan);
                _context.SaveChanges();
            }

            if (canBo.PhanQuyens.QuanLyDanhMuc == true)
            {
                var phan = new PhanQuyen();
                phan.CanBoBenhVienId = canBo.Id;
                phan.QuyenId = 2;
                _context.PhanQuyens.Add(phan);
                _context.SaveChanges();
            }

            if (canBo.PhanQuyens.BaoCao == true)
            {
                var phan = new PhanQuyen();
                phan.CanBoBenhVienId = canBo.Id;
                phan.QuyenId = 3;
                _context.PhanQuyens.Add(phan);
                _context.SaveChanges();
            }

            if (canBo.PhanQuyens.CaNhan == true)
            {
                var phan = new PhanQuyen();
                phan.CanBoBenhVienId = canBo.Id;
                phan.QuyenId = 4;
                _context.PhanQuyens.Add(phan);
                _context.SaveChanges();
            }


            return Ok();
        }

    }
}
