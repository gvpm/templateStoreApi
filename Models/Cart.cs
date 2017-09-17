using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using StoreApi.Models.Enums;
namespace StoreApi.Models
{
    public class Cart
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("UserId")]
        public string UserId { get; set; }
        [BsonElement("ProductsIds")]
        public List<string> ProductsIds { get; set; }

        public Cart()
        {
            ProductsIds = new List<string>();
        }
    }
}