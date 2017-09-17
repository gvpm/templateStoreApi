using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using StoreApi.Models.Enums;
namespace StoreApi.Models
{
    public class ChartInstruction
    {
        [BsonElement("Operation")]
        public string Operation { get; set; }
        [BsonElement("UserId")]
        public string UserId { get; set; }
        [BsonElement("ProductId")]
        public string ProductId { get; set; }

    }
}