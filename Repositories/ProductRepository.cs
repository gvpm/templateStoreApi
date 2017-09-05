using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;
using StoreApi.Models;
namespace StoreApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;

        public ProductRepository(IRepository repository)
        {
            _client = repository.GetClient();
            _server = repository.GetServer();
            _db = repository.GetDatabase();
        }

        public IEnumerable<Product> Get()
        {
            return _db.GetCollection<Product>("Products").FindAll();
        }


        public Product Get(string id)
        {
            var res = Query<Product>.EQ(p => p.Id, id);
            return _db.GetCollection<Product>("Products").FindOne(res);
        }

        public Product Create(Product p)
        {
            _db.GetCollection<Product>("Products").Save(p);
            return p;
        }

        public void Update(string id, Product p)
        {
            p.Id = id;
            var res = Query<Product>.EQ(pd => pd.Id, id);
            var operation = Update<Product>.Replace(p);
            _db.GetCollection<Product>("Products").Update(res, operation);
        }
        public void Remove(string id)
        {
            var res = Query<Product>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<Product>("Products").Remove(res);
        }
    }
}