using BlogApp.Models;
using BlogApp.Repositories;

namespace BlogApp.Services
{
    public class ArticlesService : IArticlesService
    {
        private readonly IArticlesRepository _articlesRepository;

        public ArticlesService(IArticlesRepository articlesRepository)
        {
            _articlesRepository = articlesRepository;
        }

        public List<Article> GetAllArticles()
        {
            return _articlesRepository.GetAllArticles();
        }

        public Article GetArticle(int id)
        {
            return _articlesRepository.GetArticle(id);
        }

        public Article PostArticle(Article article)
        {
            return _articlesRepository.PostArticle(article);
        }

        public void EditArticle(int id, Article article)
        {
            _articlesRepository.EditArticle(id, article);
        }

        public Article DeleteArticle(int id)
        {
            return _articlesRepository.DeleteArticle(id);
        }
    }
}
