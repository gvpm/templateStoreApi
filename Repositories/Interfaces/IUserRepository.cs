using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;
using StoreApi.Models;

namespace StoreApi.Repositories.Interfaces
{
    public interface IUserRepository
    {


        User Login(User oldUser);

        User Create(User newUser);

        void Update(string id, User u);
        void Remove(string id);
    }
}