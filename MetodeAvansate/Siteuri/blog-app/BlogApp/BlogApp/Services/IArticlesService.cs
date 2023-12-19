using BlogApp.Models;

namespace BlogApp.Services
{
    public interface IArticlesService
    {
        List<Article> GetAllArticles(string search);
        Article GetArticle(int id);
        Article PostArticle(Article article);
        void EditArticle(int id, Article article);
        Article DeleteArticle(int id);
    }
}
