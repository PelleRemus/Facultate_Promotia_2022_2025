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

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login([FromBody] UserLogin userLogin)
        {
            var user = Authenticate(userLogin);

            if (user != null)
            {
                var token = Generate(user);
                return new OkObjectResult(token);
            }

            return new NotFoundObjectResult("The user could not be found");
        }

        [HttpGet]
        public ActionResult GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var claims = identity.Claims;
                string name = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value ?? " ";

                var user = new User
                {
                    Id = int.Parse(claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0"),
                    FirstName = name?.Split(" ").First() ?? "",
                    LastName = name.Split(" ").Last() ?? "",
                    Email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value ?? ""
                };
                return new OkObjectResult(user);
            }
            return new NoContentResult();
        }

        private User? Authenticate(UserLogin userLogin)
        {
            return _database.Users.FirstOrDefault(u =>
                u.Email.ToLower() == userLogin.Email.ToLower() && u.Password == userLogin.Password);
        }

        private string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var token = new JwtSecurityToken(_config["Issuer"],
                _config["Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(2),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
