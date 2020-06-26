using BauruEmpregosBack.Authentication;
using BauruEmpregosBack.Data;
using BauruEmpregosBack.Models.Database;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Threading.Tasks;

namespace BauruEmpregosBack.Services
{
    public class AuthService
    {

        private readonly IMongoCollection<UserLogin> _collection;
        private readonly IMongoCollection<UserLogin> _collection;
        private readonly IMongoCollection<UserLogin> _collection;

        public AuthService(IStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            var _collection = database.GetCollection<UserLogin>(Collection.UserLogin);
        }

        public async Task<bool> IsValidLoginAsync(UserLogin userLogin)
        {



            UserLogin user = await _collection.AsQueryable().Where(x => x)
            if (user == null)
                return false;

            return true;
        }

        public string AddToken(UserLogin userLogin)
            => AutenticationTokenHandler.GenerationToken(userLogin);
    }
}
