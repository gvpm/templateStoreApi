using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;
using StoreApi.Models;

namespace StoreApi.Repositories.Interfaces
{
    public interface IHistoryRepository
    {
        IEnumerable<History> Get();

        History Get(string id);

        IEnumerable<History> GetAll(string id);

        History Create(History p);
    }
}