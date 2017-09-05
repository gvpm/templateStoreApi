using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using StoreApi.Models.Enums;

namespace StoreApi.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("ProductName")]
        public string ProductName { get; set; }
        [BsonElement("ProductDescription")]
        public string ProductDescription { get; set; }
        [BsonElement("ProductLink")]
        public string ProductLink { get; set; }
        [BsonElement("ProductPriceInCents")]
        public int ProductPriceInCents { get; set; }
        [BsonElement("ProductCategory")]
        public CategoryEnum ProductCategory { get; set; }



    }
}