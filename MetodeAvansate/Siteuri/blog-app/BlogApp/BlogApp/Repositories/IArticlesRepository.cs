using BlogApp.Models;

namespace BlogApp.Repositories
{
    public interface IArticlesRepository
    {
        List<Article> GetAllArticles(string search);
        Article GetArticle(int id);
        Article PostArticle(Article article);
        void EditArticle(int id, Article article);
        Article DeleteArticle(int id);
    }
}
