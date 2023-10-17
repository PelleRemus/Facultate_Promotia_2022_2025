using BlogApp.Models;

namespace BlogApp.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DatabaseContext _dbContext;

        public UsersRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public User GetUser(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(user => user.Id == id);
            if (user == null)
                throw new KeyNotFoundException($"Can not find user with id {id}");
            return user;
        }

        public User PostUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public void EditUser(int id, User user)
        {
            var dbUser = _dbContext.Users.FirstOrDefault(user => user.Id == id);

            if (dbUser == null)
                throw new KeyNotFoundException($"Can not find user with id {id}");

            dbUser.LastName = user.LastName;
            dbUser.FirstName = user.FirstName;
            dbUser.NickName = user.NickName;
            dbUser.Password = user.Password;
            dbUser.Email = user.Email;
            dbUser.Phone = user.Phone;
            dbUser.BirthDate = user.BirthDate;

            _dbContext.SaveChanges();
        }

        public User DeleteUser(int id)
        {
            var dbUser = _dbContext.Users.FirstOrDefault(user => user.Id == id);

            if (dbUser == null)
                throw new KeyNotFoundException($"Can not find user with id {id}");

            _dbContext.Users.Remove(dbUser);
            _dbContext.SaveChanges();
            return dbUser;
        }
    }
}
