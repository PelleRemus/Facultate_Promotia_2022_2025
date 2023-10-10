using BlogApp.Models;
using BlogApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    [Controller]
    [Route("/api/[controller]")]
    public class UsersController
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public ActionResult GetAllUsers()
        {
            var users = _usersService.GetAllUsers();
            return new OkObjectResult(users);
        }

        [HttpGet("{id}")]
        public ActionResult GetUser(int id)
        {
            var user = _usersService.GetUser(id);
            return new OkObjectResult(user);
        }

        [HttpPost]
        public ActionResult PostUser([FromBody] User user)
        {
            var dbUser = _usersService.PostUser(user);
            return new OkObjectResult(dbUser);
        }

        [HttpPut("{id}")]
        public ActionResult EditUser(int id, [FromBody] User user)
        {
            _usersService.EditUser(id, user);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var dbUser = _usersService.DeleteUser(id);
            return new OkObjectResult(dbUser);
        }
    }
}
