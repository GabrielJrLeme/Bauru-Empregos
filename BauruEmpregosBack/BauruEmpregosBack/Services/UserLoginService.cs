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
    public class UserLoginService
    {


        private readonly IMongoCollection<User> _collection;

        public UserLoginService(IStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<User>(Collection.UserLogin);
        }




        /// <summary>
        /// Cria um usuario
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> CreateUserLoginAsync(User model)
        {

            bool result = await VuetifyUserExistAsync(model);

            if (!result)
                return false;

            //Hash senha

            await _collection.InsertOneAsync(model);
            return true;
        }
        



        public async Task ChengeUserLoginAsync(User user)
        {
            User userLogin = await GetUserLoginAsync(user.Email,user.Login);

            userLogin = user;

            await _collection.ReplaceOneAsync(x => x.Id.Equals(userLogin.Id), userLogin);
        }


        public async Task DeleteUserLogin(string id)
        {
            User userLogin = await GetUserLoginIdAsync(id);

            userLogin.Activy = false;
        }



        /// <summary>
        /// Buscar um usuario em especifico
        /// </summary>
        /// <param name="email"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        private async Task<User> GetUserLoginAsync(string email,string login)
            => await _collection.AsQueryable().Where(x => x.Email.Equals(email) && x.Login.Equals(login))
                                           .Where(x => x.Activy.Equals(true))
                                           .FirstOrDefaultAsync();


        private async Task<User> GetUserLoginIdAsync(string id)
            => await _collection.AsQueryable().Where(x => x.Id.Equals(id))
                                           .Where(x => x.Activy.Equals(true))
                                           .FirstOrDefaultAsync();


        /// <summary>
        /// Verificar se existe um usuario ja criado.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private async Task<bool> VuetifyUserExistAsync(User user)
        {
            User result = await _collection.AsQueryable()
                                           .Where(x => x.Email.Equals(user.Email) || x.Login.Equals(user.Login))
                                           .Where(x => x.Activy.Equals(true))
                                           .FirstOrDefaultAsync();

            if (result != null)
                return false;

            return true;
        }
            


    }
}
