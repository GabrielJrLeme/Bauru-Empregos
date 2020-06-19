using BauruEmpregosBack.Data;
using BauruEmpregosBack.Models.Database;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BauruEmpregosBack.Services
{
    public class UserService
    {

        private readonly IMongoCollection<UserLogin> _collectionLgn;
        private readonly IMongoCollection<UserClient> _collectionClt;

        public UserService(IStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _collectionLgn = database.GetCollection<UserLogin>(Collection.UserLogin);
            _collectionClt = database.GetCollection<UserClient>(Collection.UserLogin);
        }



    }
}
