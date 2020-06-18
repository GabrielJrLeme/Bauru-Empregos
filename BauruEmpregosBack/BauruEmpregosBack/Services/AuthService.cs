
using BauruEmpregosBack.Data;
using BauruEmpregosBack.Models.Database;
using BauruEmpregosBack.Models.Enum;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BauruEmpregosBack.Services
{
    public class AuthService
    {

        private readonly IMongoCollection<User> _collection;
        private readonly TokenService _token;

        public AuthService(IStoreDatabaseSettings settings, TokenService token)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<User>(Collection.User);

            _token = token;
        }




        public async Task<User> LoginUserAsync(User model)
        {

            User user = await _collection.AsQueryable()
                                         .Where(x => x.Login.Equals(model.Login) || x.Email.Equals(model.Email) && x.Password.Equals(model.Password))
                                         .Where(x => x.Activy.Equals(true))
                                         .FirstOrDefaultAsync();
           //Hash de senha


            user.Token = _token.GenerationToken(user);

            user.DateLeftLogin = DateTime.Now;

            return user;
        }



    }
}
