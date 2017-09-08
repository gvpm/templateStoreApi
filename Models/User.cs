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
        [BsonElement("UserName")]
        public string UserName { get; set; }
        [BsonElement("UserEmail")]
        public string UserEmail { get; set; }
        [BsonElement("UserPassword")]
        public string UserPassword { get; set; }
        [BsonElement("UserHashPassword")]
        public string UserHashPassword { get; set; }




    }
}