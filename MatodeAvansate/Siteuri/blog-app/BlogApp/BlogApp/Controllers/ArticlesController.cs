using BlogApp.Models;
using BlogApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    [Controller]
    [Route("/api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticlesService _articlesService;

        public ArticlesController(IArticlesService articlesService)
        {
            _articlesService = articlesService;
        }

        [HttpGet]
        public ActionResult GetAllArticles()
        {
            var articles = _articlesService.GetAllArticles();
            return new OkObjectResult(articles);
        }

        [HttpGet("{id}")]
        public ActionResult GetArticle(int id)
        {
            var article = _articlesService.GetArticle(id);
            return new OkObjectResult(article);
        }

        [HttpPost]
        public ActionResult PostArticle([FromBody] Article article)
        {
            var dbArticle = _articlesService.PostArticle(article);
            return new OkObjectResult(dbArticle);
        }

        [HttpPut("{id}")]
        public ActionResult EditArticle(int id, [FromBody] Article article)
        {
            _articlesService.EditArticle(id, article);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteArticle(int id)
        {
            Article dbArticle = _articlesService.DeleteArticle(id);
            return new OkObjectResult(dbArticle);
        }
    }
}
