namespace article_app.Models{
    public class ArticleDatabaseSettings : IArticleDatabaseSettings
    {
        public string ArticlesCollectionName {get;set;}
        public string ConnectionString { get;set; }
        public string DatabaseName { get;set;}
    }

    public interface IArticleDatabaseSettings{

       string ArticlesCollectionName{get;set;}
       string ConnectionString{get;set;}
       string DatabaseName{get;set;}
  }


}