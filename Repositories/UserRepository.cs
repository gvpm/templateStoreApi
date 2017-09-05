using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;
using StoreApi.Models;
using StoreApi.Repositories.Interfaces;
namespace StoreApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;

        public UserRepository(IRepository repository)
        {
            _client = repository.GetClient();
            _server = repository.GetServer();
            _db = repository.GetDatabase();
        }

        public IEnumerable<User> Get()
        {
            return _db.GetCollection<User>("Users").FindAll();
        }


        public User Get(string id)
        {
            var res = Query<User>.EQ(p => p.Id, id);
            return _db.GetCollection<User>("Users").FindOne(res);
        }

        public User Create(User u)
        {
            _db.GetCollection<User>("Users").Save(u);
            return u;
        }

        public void Update(string id, User u)
        {
            u.Id = id;
            var res = Query<User>.EQ(pd => pd.Id, id);
            var operation = Update<User>.Replace(u);
            _db.GetCollection<User>("Users").Update(res, operation);
        }
        public void Remove(string id)
        {
            var res = Query<User>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<User>("Users").Remove(res);
        }
    }
}