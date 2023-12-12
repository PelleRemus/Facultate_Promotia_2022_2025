using BlogApp.DTO;
using BlogApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogApp.Controllers
{
    [Controller]
    [Route("/api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly DatabaseContext _database;
        private readonly IConfiguration _config;

        public LoginController(DatabaseContext database, IConfiguration config)
        {
            _database = database;
            _config = config;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login([FromBody] UserLogin userLogin)
        {
            try
            {
                var user = Authenticate(userLogin);
                var token = GenerateToken(user);
                return new OkObjectResult(new { token });
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        private User Authenticate(UserLogin userLogin)
        {
            var user = _database.Users.FirstOrDefault(u =>
                u.Email.ToLower() == userLogin.Email.ToLower() && u.Password == userLogin.Password);

            if (user == null)
                throw new KeyNotFoundException($"UserName or password are incorrect!");

            return user;
        }

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"] ?? ""));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };
            var token = new JwtSecurityToken(_config["JWT:Issuer"],
                _config["JWT:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(2),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
