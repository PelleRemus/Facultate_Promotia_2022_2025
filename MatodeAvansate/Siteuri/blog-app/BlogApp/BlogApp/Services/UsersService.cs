using BlogApp.Models;
using BlogApp.Repositories;

namespace BlogApp.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public List<User> GetAllUsers()
        {
            return _usersRepository.GetAllUsers();
        }

        public User GetUser(int id)
        {
            return _usersRepository.GetUser(id);
        }

        public User PostUser(User user)
        {
            return _usersRepository.PostUser(user);
        }

        public void EditUser(int id, User user)
        {
            _usersRepository.EditUser(id, user);
        }

        public User DeleteUser(int id)
        {
            return _usersRepository.DeleteUser(id);
        }
    }
}
