using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace StoreApi.Repositories.Interfaces
{
    public interface IRepository
    {
        MongoClient GetClient();
        MongoServer GetServer();
        MongoDatabase GetDatabase();
    }
}