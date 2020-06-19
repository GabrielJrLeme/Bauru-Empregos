using BauruEmpregosBack.Data;
using BauruEmpregosBack.Models.Database;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace BauruEmpregosBack.Services
{
    public class AdminService
    {

        private readonly IMongoCollection<UserLogin> _collectionLgn;
        private readonly IMongoCollection<UserAdmin> _collectionAdm;

        public AdminService(IStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _collectionLgn = database.GetCollection<UserLogin>(Collection.UserLogin);
            _collectionAdm = database.GetCollection<UserAdmin>(Collection.UserAdmin);
        }


        public async Task<bool> CreateUserAsync(UserAdmin model)
        {

            UserLogin userLogin = await _collectionLgn.AsQueryable()
                                          .Where(x => x.Email.Equals(model.Email) || x.Login.Equals(model.Login))
                                          .Where(x => x.Activy)
                                          .FirstOrDefaultAsync();


            model.Role = "admin";

            //Hash senha

            await _collectionLgn.InsertOneAsync(model);
            await _collectionAdm.InsertOneAsync(model);

            return true;
        }

    }
}
