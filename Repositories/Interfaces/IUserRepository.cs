using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;
using StoreApi.Models;

namespace StoreApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> Get();

        User Get(string id);

        User Create(User u);

        void Update(string id, User u);
        void Remove(string id);
    }
}