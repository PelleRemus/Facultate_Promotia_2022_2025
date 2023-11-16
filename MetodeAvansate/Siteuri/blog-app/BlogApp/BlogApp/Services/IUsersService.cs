using BlogApp.Models;

namespace BlogApp.Services
{
    public interface IUsersService
    {
        List<User> GetAllUsers();
        User GetUser(int id);
        User PostUser(User user);
        void EditUser(int id, User user);
        User DeleteUser(int id);
    }
}
