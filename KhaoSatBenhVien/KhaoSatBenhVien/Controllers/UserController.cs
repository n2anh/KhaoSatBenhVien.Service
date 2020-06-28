using KhaoSatBenhVien.Models;
using KhaoSatBenhVien.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KhaoSatBenhVien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly KhaoSatDbContext _context;
        private readonly IConfiguration _config;

        public UserController(
            UserManager<ApplicationUser> userManager,
            IConfiguration config,
            KhaoSatDbContext context
            )
        {
            _userManager = userManager;
            _config = config;
            _context = context;
        }


        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authencate(LoginRequest request)
        {
            var user = await _context.CanBoBenhViens.Where(x => x.Username == request.UserName && x.Password == request.Password).FirstOrDefaultAsync();
            if (user == null) return NotFound();

            var boPhan = _context.BoPhans.Where(x => x.Id == user.BoPhanId).FirstOrDefault();

            var phanQuyens = _context.PhanQuyens.Where(x => x.CanBoBenhVien.Id == user.Id).ToList();

            //var quyens = new List<Quyen>();
            //foreach (var item in phanQuyens)
            //{
            //    var q = _context.Quyens.Where(x => x.Id == item.Quyen.Id).FirstOrDefault();
            //    quyens.Add(q);
            //}



            var claims = new[]
            {
                new Claim("TenCanBo",user.TenCanBo),
                new Claim("ChucVu", user.ChucVu),
                new Claim("UserName", user.Username),
                new Claim("Id", user.Id.ToString()),
                new Claim("BoPhan", boPhan.TenBoPhan),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }


        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterRequest request)
        {
            var user = new ApplicationUser()
            {
                Email = request.Email,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber,
                Id = Guid.NewGuid().ToString()
            };

            await _userManager.CreateAsync(user, request.Password);
            return Ok();
        }

    }
}