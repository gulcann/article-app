using System.Collections.Generic;
using article_app.Models;
using article_app.Services;
using Microsoft.AspNetCore.Mvc;

namespace article_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly ArticleService _articleService;
        public ArticleController(ArticleService articleService)
        {
            _articleService = articleService;
        }
        [Route("~/api/GetAllArticles")]
        [HttpGet]
        public ActionResult<List<ArticleInfo>> Get()
        {
            return _articleService.Get();
        }
        [Route("~/api/GetArticle/{id}")]
        [HttpGet("{id:length(24)}", Name = "GetArticle")]
        public ActionResult<ArticleInfo> Get(string id)
        {
            var article = _articleService.Get(id);
            if(article == null)
            {
                return NotFound();
            }
            return article;
        }
        [Route("~/api/AddArticle")]
        [HttpPost]
        public ActionResult<ArticleInfo> Create(ArticleInfo article)
        {
            _articleService.Create(article);
            return CreatedAtRoute("GetArticle", new {id = article.Id.ToString()},article);
        }
        [Route("~/api/UpdateArticle/{id}")]
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, ArticleInfo articleIn)
        {
            var article = _articleService.Get(id);
            if(article == null)
            {
                return NotFound();
            }
            _articleService.Update(id,articleIn);
            return NoContent();
        }
        [Route("~/api/DeleteArticle/{id}")]
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var article = _articleService.Get(id);
            if(article == null)
            {
                return NotFound();
            }
            _articleService.Remove(id);
            return NoContent();
        }
    }
}
