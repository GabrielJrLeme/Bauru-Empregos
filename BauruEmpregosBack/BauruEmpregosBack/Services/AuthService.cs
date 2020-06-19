using BauruEmpregosBack.Data;
using BauruEmpregosBack.Models.Database;
using BauruEmpregosBack.Models.Enum;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BauruEmpregosBack.Services
{
    public class AuthService
    {


        private readonly IMongoCollection<UserLogin> _collection;

        public AuthService(IStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<UserLogin>(Collection.UserLogin);
        }



        public async Task<bool> IsValidLoginAsync(UserLogin model)
        {

            var user = await _collection.AsQueryable().Where(x => x.Equals(model.Login) && x.Equals(model.Email))
                                                .Where(x => x.Activy)
                                                .FirstOrDefaultAsync();


            if (user == null)
                return false;

            var passHash = HashService.GenerationPasswordHash(user.Email, user.Role, model.Password);
            return passHash.Equals(user.Password);  
        }
        

        public async Task<string> AddToken(UserLogin model)
        {
            return "dfsdf";
        }


    }
}
