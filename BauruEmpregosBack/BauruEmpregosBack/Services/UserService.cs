using BauruEmpregosBack.Data;
using BauruEmpregosBack.Models.Database;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using MongoDB.Driver.Linq;
using System.Threading.Tasks;

namespace BauruEmpregosBack.Services
{

    /// <summary>
    /// Rota usuario geral
    /// </summary>
    public class UserService
    {


        private readonly IMongoCollection<User> _collection;

        public UserService(IStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<User>(Collection.UserLogin);
        }


        public async Task<User> CreateUserLoginAsync(User model)
        {

            User user = await VuetifyUserExistAsync(model);

            //Hash senha

            await _collection.InsertOneAsync(user);
            return user;
        }
        

        private async Task<User> VuetifyUserExistAsync(User user)
            => await _collection.AsQueryable()
                          .Where(x => x.Email.Equals(user.Email) || x.Login.Equals(user.Login))
                          .Where(x => x.Activy.Equals(true))
                          .FirstOrDefaultAsync();


    }
}
