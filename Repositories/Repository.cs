using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;
using StoreApi.Repositories.Interfaces;
namespace StoreApi.Repositories
{

    public class Repository : IRepository
    {
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;

        public Repository()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _server = _client.GetServer();
            _db = _server.GetDatabase("StoreDB");
        }

        public MongoClient GetClient()
        {
            return _client;
        }
        public MongoServer GetServer()
        {
            return _server;
        }
        public MongoDatabase GetDatabase()
        {
            return _db;
        }

    }
}