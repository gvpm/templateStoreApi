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
        //MongoClient _client;
        //MongoServer _server;
        MongoDatabase _db;

        public UserRepository(IRepository repository)
        {
            //_client = repository.GetClient();
            //_server = repository.GetServer();
            _db = repository.GetDatabase();
        }

        public User GetUserById(string userID)
        {
            var res = Query<User>.EQ(u => u.Id, userID);
            var _user = _db.GetCollection<User>("Users").FindOne(res);
            if(_user != null){
            _user.UserHashPassword = "******";
            }
            return _user;
        }

        public User Login(User oldUser)
        {
            var res = Query<User>.EQ(u => u.UserName, oldUser.UserName);
            var _user = _db.GetCollection<User>("Users").FindOne(res);

            if (_user != null)
            {
                var oldUserHashPassword = oldUser.UserPassword.GetHashCode().ToString();
                if (oldUserHashPassword.Equals(_user.UserHashPassword))
                {
                    _user.UserHashPassword = "******";
                    return _user;
                }
            }
            return null;
        }

        public User Create(User newUser)
        {
            var res = Query<User>.EQ(u => u.UserName, newUser.UserName);
            var _user = _db.GetCollection<User>("Users").FindOne(res);

            var res2 = Query<User>.EQ(u => u.UserEmail, newUser.UserEmail);
            var _user2 = _db.GetCollection<User>("Users").FindOne(res2);

            if (_user2 != null || _user != null)
            {
                return null;
            }

            newUser.UserHashPassword = newUser.UserPassword.GetHashCode().ToString();
            newUser.UserPassword = "******";
            _db.GetCollection<User>("Users").Save(newUser);

            newUser.UserHashPassword = "******";

            return newUser;
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