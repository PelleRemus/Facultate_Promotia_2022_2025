using BlogApp.Models;
using BlogApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        public ActionResult GetAllArticles([FromQuery] string search)
        {
            try
            {
                var articles = _articlesService.GetAllArticles(search);
                return new OkObjectResult(articles);
            }
            catch
            {
                return new ObjectResult("Something went wrong!")
                {
                    StatusCode = 500
                };
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetArticle([FromRoute] int id)
        {
            try
            {
                var article = _articlesService.GetArticle(id);
                return new OkObjectResult(article);
            }
            catch (KeyNotFoundException ex)
            {
                return new NotFoundObjectResult(ex.Message);
            }
            catch
            {
                return new ObjectResult("Something went wrong!")
                {
                    StatusCode = 500
                };
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult PostArticle([FromBody] Article article)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            try
            {
                int authorId = int.Parse(identity?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0");
                article.AuthorId = authorId;

                var dbArticle = _articlesService.PostArticle(article);
                return new OkObjectResult(dbArticle);
            }
            catch (KeyNotFoundException ex)
            {
                return new NotFoundObjectResult(ex.Message);
            }
            catch
            {
                return new ObjectResult("Something went wrong!")
                {
                    StatusCode = 500
                };
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult EditArticle(int id, [FromBody] Article article)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var claims = identity?.Claims;
            int userId = int.Parse(claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0");
            string role = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value ?? "";

            if (article.AuthorId != userId && role != "Admin")
            {
                return new ForbidResult();
            }

            try
            {
                _articlesService.EditArticle(id, article);
                return new NoContentResult();
            }
            catch (KeyNotFoundException ex)
            {
                return new NotFoundObjectResult(ex.Message);
            }
            catch
            {
                return new ObjectResult("Something went wrong!")
                {
                    StatusCode = 500
                };
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult DeleteArticle(int id)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var claims = identity?.Claims;
            int userId = int.Parse(claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0");
            string role = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value ?? "";

            try
            {
                Article existing = _articlesService.GetArticle(id);
                if (existing.AuthorId != userId && role != "Admin")
                {
                    return new ForbidResult();
                }

                Article dbArticle = _articlesService.DeleteArticle(id);
                return new OkObjectResult(dbArticle);
            }
            catch (KeyNotFoundException ex)
            {
                return new NotFoundObjectResult(ex.Message);
            }
            catch
            {
                return new ObjectResult("Something went wrong!")
                {
                    StatusCode = 500
                };
            }
        }
    }
}
