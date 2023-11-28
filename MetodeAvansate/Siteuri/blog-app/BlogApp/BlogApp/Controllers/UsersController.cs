using BlogApp.Models;
using BlogApp.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    [Controller]
    [Route("/api/[controller]")]
    public class UsersController
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

        [HttpPost]
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
