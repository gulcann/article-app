using System.Collections.Generic;
using article_app.Models;
using MongoDB.Driver;

namespace article_app.Services
{
    public class ArticleService
    {
        private readonly IMongoCollection<ArticleInfo> _articles;

        public ArticleService(IArticleDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _articles = database.GetCollection<ArticleInfo>(settings.ArticlesCollectionName);
        }

        public List<ArticleInfo> Get()
        {
            return _articles.Find(article => true).ToList();
        }
        public ArticleInfo Get(string id)
        {
            return _articles.Find<ArticleInfo>(article => article.Id == id).FirstOrDefault();
        }
        public ArticleInfo Create(ArticleInfo article)
        {
            _articles.InsertOne(article);
            return article;
        }
        public void Update(string id,ArticleInfo article)
        {
            _articles.ReplaceOne(artic => artic.Id == id,article);
        }
        public void Remove(string id)
        {
            _articles.DeleteOne(article => article.Id == id);
        }
        public void Remove(ArticleInfo article)
        {
            _articles.DeleteOne(artic => artic.Id == article.Id);
        }
    }
}