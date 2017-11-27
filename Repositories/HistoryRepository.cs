using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;
using StoreApi.Models;
using StoreApi.Repositories.Interfaces;
namespace StoreApi.Repositories
{
    public class HistoryRepository : IHistoryRepository
    {
        //MongoClient _client;
        //MongoServer _server;
        MongoDatabase _db;

        public HistoryRepository(IRepository repository)
        {
            //_client = repository.GetClient();
            //_server = repository.GetServer();
            _db = repository.GetDatabase();
        }

        public IEnumerable<History> Get()
        {
            return _db.GetCollection<History>("Histories").FindAll();
        }


        public History Get(string id)
        {
            var res = Query<History>.EQ(p => p.Id, id);
            return _db.GetCollection<History>("Histories").FindOne(res);
        }

        public IEnumerable<History> GetAll(string id)
        {
            IEnumerable<History> histories = _db.GetCollection<History>("Histories").FindAll();
            List<History> historiesFromUser = new List<History>();

            foreach (var history in histories)
            {
                if (history.Cart.User.Id == id){
                    historiesFromUser.Add(history);
                }
            }
            

            return historiesFromUser;
        }



        public History Create(History p)
        {
            _db.GetCollection<History>("Histories").Save(p);
            return p;
        }


    }
}