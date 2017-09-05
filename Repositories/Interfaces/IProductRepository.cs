using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;
using StoreApi.Models;

namespace StoreApi.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> Get();

        Product Get(string id);

        Product Create(Product p);

        void Update(string id, Product p);
        void Remove(string id);
    }
}