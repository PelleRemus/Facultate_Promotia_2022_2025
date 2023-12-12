using BlogApp.Models;
using BlogApp.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogApp.Controllers
{
    [Controller]
    [Route("/api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly AbstractValidator<User> _validator;

        public UsersController(IUsersService usersService, AbstractValidator<User> validator)
        {
            _usersService = usersService;
            _validator = validator;
        }

        [HttpGet]
        public ActionResult GetAllUsers()
        {
            try
            {
                var users = _usersService.GetAllUsers();
                return new OkObjectResult(users);
            }
            catch
            {
                return new ObjectResult("Something went wrong!")
                {
                    StatusCode = 500
                };
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetUser(int id)
        {
            try
            {
                var user = _usersService.GetUser(id);
                return new OkObjectResult(user);
            }
            catch (KeyNotFoundException ex)
            {
                return new NotFoundObjectResult(ex.Message);
            }
            catch
            {
                return new ObjectResult("Something went wrong!")
                {
                    StatusCode = 500
                };
            }
        }

        [HttpGet("current")]
        [Authorize]
        public ActionResult GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            try
            {
                if (identity != null)
                {
                    var claims = identity.Claims;
                    int userId = int.Parse(claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0");

                    var user = _usersService.GetUser(userId);
                    return new OkObjectResult(user);
                }
                return new NotFoundResult();
            }
            catch (KeyNotFoundException ex)
            {
                return new NotFoundObjectResult(ex.Message);
            }
            catch
            {
                return new ObjectResult("Something went wrong!")
                {
                    StatusCode = 500
                };
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult PostUser([FromBody] User user)
        {
            try
            {
                var validation = _validator.Validate(user);
                if (!validation.IsValid)
                    return new BadRequestObjectResult(validation.Errors.Select(error => error.ErrorMessage));

                var dbUser = _usersService.PostUser(user);
                return new OkObjectResult(dbUser);
            }
            catch
            {
                return new ObjectResult("Something went wrong!")
                {
                    StatusCode = 500
                };
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult EditUser(int id, [FromBody] User user)
        {
            try
            {
                var validation = _validator.Validate(user);
                if (!validation.IsValid)
                    return new BadRequestObjectResult(validation.Errors);

                _usersService.EditUser(id, user);
                return new NoContentResult();
            }
            catch (KeyNotFoundException ex)
            {
                return new NotFoundObjectResult(ex.Message);
            }
            catch
            {
                return new ObjectResult("Something went wrong!")
                {
                    StatusCode = 500
                };
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                var dbUser = _usersService.DeleteUser(id);
                return new OkObjectResult(dbUser);
            }
            catch (KeyNotFoundException ex)
            {
                return new NotFoundObjectResult(ex.Message);
            }
            catch
            {
                return new ObjectResult("Something went wrong!")
                {
                    StatusCode = 500
                };
            }
        }
    }
}
