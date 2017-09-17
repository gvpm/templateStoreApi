
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using StoreApi.Models.Enums;

namespace StoreApi.Models
{
    public class ExternalCart
    {

        [BsonElement("CartId")]
        public string Id { get; set; }

        [BsonElement("User")]
        public User User { get; set; }
        [BsonElement("Products")]
        public List<Product> Products { get; set; }
        [BsonElement("TotalValue")]
        public int TotalValue { get; set; }
        public ExternalCart()
        {
            Products = new List<Product>();
        }
    }
}