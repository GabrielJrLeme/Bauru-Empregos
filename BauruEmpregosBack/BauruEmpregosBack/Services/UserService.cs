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

        private readonly IMongoCollection<User> _collection;

        public UserService(IStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<User>(Collection.UserLogin);
        }



        


    }
}
