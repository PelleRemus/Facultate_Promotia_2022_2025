using BlogApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Repositories
{
    public class ArticlesRepository : IArticlesRepository
    {
        private readonly DatabaseContext _dbContext;

        public ArticlesRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Article> GetAllArticles()
        {
            return _dbContext.Articles.Include(a => a.Author).ToList();
        }

        public Article GetArticle(int id)
        {
            var article = _dbContext.Articles
                .Include(a => a.Author)
                .FirstOrDefault(article => article.Id == id);

            if (article == null)
                throw new KeyNotFoundException($"Can not find article with id {id}");
            return article;
        }

        public Article PostArticle(Article article)
        {
            var user = _dbContext.Users.FirstOrDefault(user => user.Id == article.AuthorId);
            if (user == null)
                throw new KeyNotFoundException($"Can not find user with id {article.AuthorId}");

            _dbContext.Articles.Add(article);
            _dbContext.SaveChanges();
            return article;
        }

        public void EditArticle(int id, Article article)
        {
            var dbArticle = _dbContext.Articles.FirstOrDefault(article => article.Id == id);
            if (dbArticle == null)
                throw new KeyNotFoundException($"Can not find article with id {id}");

            var user = _dbContext.Users.FirstOrDefault(user => user.Id == article.AuthorId);
            if (user == null)
                throw new KeyNotFoundException($"Can not find user with id {article.AuthorId}");

            dbArticle.Title = article.Title;
            dbArticle.Content = article.Content;

            _dbContext.SaveChanges();
        }

        public Article DeleteArticle(int id)
        {
            var dbArticle = _dbContext.Articles.FirstOrDefault(article => article.Id == id);

            if (dbArticle == null)
                throw new KeyNotFoundException($"Can not find article with id {id}");

            _dbContext.Articles.Remove(dbArticle);
            _dbContext.SaveChanges();
            return dbArticle;
        }
    }
}
