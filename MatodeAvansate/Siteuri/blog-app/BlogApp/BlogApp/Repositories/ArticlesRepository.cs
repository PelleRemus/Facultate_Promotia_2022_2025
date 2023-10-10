using BlogApp.Models;

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
            return _dbContext.Articles.ToList();
        }

        public Article GetArticle(int id)
        {
            return _dbContext.Articles.First(article => article.Id == id);
        }

        public Article PostArticle(Article article)
        {
            _dbContext.Articles.Add(article);
            _dbContext.SaveChanges();
            return article;
        }

        public void EditArticle(int id, Article article)
        {
            var dbArticle = _dbContext.Articles.First(article => article.Id == id);

            if (dbArticle != null)
            {
                dbArticle.Title = article.Title;
                dbArticle.Content = article.Content;
            }
            _dbContext.SaveChanges();
        }

        public Article DeleteArticle(int id)
        {
            var dbArticle = _dbContext.Articles.First(article => article.Id == id);
            _dbContext.Articles.Remove(dbArticle);
            _dbContext.SaveChanges();
            return dbArticle;
        }
    }
}
