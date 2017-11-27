using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;
using StoreApi.Models;

namespace StoreApi.Repositories.Interfaces
{
    public interface IWishListRepository
    {
        ExternalCart Get(string id);
        ExternalCart RemoveProduct(string userId, string productId);
        ExternalCart AddProduct(string userId, string productId);
    }
}