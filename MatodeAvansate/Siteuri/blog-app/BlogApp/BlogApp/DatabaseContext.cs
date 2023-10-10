using BlogApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApp
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options) { }

        public DbSet<Article> Articles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
