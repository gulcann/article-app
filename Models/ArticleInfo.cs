

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace article_app.Models{
public class ArticleInfo{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id{get; set;}

    [BsonElement("title")]
    [JsonProperty("Title")]
    public string Title{get;set;}
    [BsonElement("author")]
    [JsonProperty("Author")]
    public string Author{get;set;}

    [BsonElement("category")]
    [JsonProperty("Category")]
    public string Category{get;set;}

    [BsonElement("content")] 
    [JsonProperty("Content")]
    public string Content{get;set;}

}
}