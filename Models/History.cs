
using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using StoreApi.Models.Enums;

namespace StoreApi.Models
{
    public class History
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Date")]
        public DateTime Date { get; set; }


        [BsonElement("Cart")]
        public ExternalCart Cart { get; set; }
        

        public History(ExternalCart cart)
        {
            Date = DateTime.Now.Date;
            Cart = cart;
        }
    }
}