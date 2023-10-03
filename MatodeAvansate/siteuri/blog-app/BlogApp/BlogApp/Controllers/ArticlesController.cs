using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    [Controller]
    [Route("/api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        public static List<Article> articles = new List<Article>
        {
            new Article { Id = 1, AuthorId = 1, Title = "My Article", Content = "very creative content" }
        };

        [HttpGet]
        public ActionResult GetAllArticles()
        {
            return new OkObjectResult(articles);
        }

        [HttpGet("{id}")]
        public ActionResult GetArticle(int id)
        {
            return new OkObjectResult(articles.FirstOrDefault(article => article.Id == id));
        }

        [HttpPost]
        public ActionResult PostArticle([FromBody] Article article)
        {
            articles.Add(article);
            return new OkObjectResult(article);
        }

        [HttpPut("{id}")]
        public ActionResult EditArticle(int id, [FromBody] Article article)
        {
            Article dbArticle = articles.FirstOrDefault(article => article.Id == id);

            if (dbArticle != null)
            {
                dbArticle.Title = article.Title;
                dbArticle.Content = article.Content;
            }

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteArticle(int id)
        {
            Article dbArticle = articles.FirstOrDefault(article => article.Id == id);
            articles.Remove(dbArticle);
            return new OkObjectResult(dbArticle);
        }
    }
}
