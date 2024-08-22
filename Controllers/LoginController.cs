using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using pharma.Data;
using pharma.Model;

namespace pharma.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly PharmaDbContext _context;

        public LoginController(IConfiguration configuration, PharmaDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromBody] User model)
        {
            if (_context.UserDetails.Any(u => u.UserName == model.UserName))
            {
                return BadRequest(new { Error = "User already exists" });
            }

            _context.UserDetails.Add(new User
            {
                UserName = model.UserName,
                UserPassword = model.UserPassword,
                Contact = model.Contact,
                UserAddress = model.UserAddress,
                Role = model.Role,
                Email = model.Email
            });
            await _context.SaveChangesAsync();
            return Ok(new { Message = "User registered successfully" });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Login model)
        {
            var user = await AuthenticateUserAsync(model.UserName, model.UserPassword);

            if (user != null)
            {
                var token = GenerateJwtToken(user);
                SetTokenCookie(token);
                return Ok(new { Message = "Successfully logged in", Token = token,user.UserId,user.UserName ,user.Email,user.UserPassword,user.Approval});
            }

            return BadRequest(new { Error = "Invalid username or password" });
        }

        private async Task<User> AuthenticateUserAsync(string username, string password)
        {
            var user = await _context.UserDetails.FirstOrDefaultAsync(u => u.UserName == username && u.UserPassword == password);
            return user;
        }

        private string GenerateJwtToken(User user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = Encoding.ASCII.GetBytes(jwtSettings["SecretKey"]);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.Role) 
                }),
                Expires = DateTime.UtcNow.AddHours(4), 
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        private void SetTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddMinutes(10) 
            };
            Response.Cookies.Append("JwtToken", token, cookieOptions);
        }
    }
}
