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
            return _dbContext.Users.First(user => user.Id == id);
        }

        public User PostUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public void EditUser(int id, User user)
        {
            var dbUser = _dbContext.Users.First(user => user.Id == id);

            if (dbUser != null)
            {
                dbUser.LastName = user.LastName;
                dbUser.FirstName = user.FirstName;
                dbUser.NickName = user.NickName;
                dbUser.Password = user.Password;
                dbUser.Email = user.Email;
                dbUser.Phone = user.Phone;
                dbUser.BirthDate = user.BirthDate;
            }
            _dbContext.SaveChanges();
        }

        public User DeleteUser(int id)
        {
            var dbUser = _dbContext.Users.First(user => user.Id == id);
            _dbContext.Users.Remove(dbUser);
            _dbContext.SaveChanges();
            return dbUser;
        }
    }
}
