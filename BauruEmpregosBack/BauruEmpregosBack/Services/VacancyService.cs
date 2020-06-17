using BauruEmpregosBack.Data;
using BauruEmpregosBack.Models;
using BauruEmpregosBack.Models.Database;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BauruEmpregosBack.Services
{
    public class VacancyService
    {

        private readonly IMongoCollection<Vacancys> _collection;

        public VacancyService(IStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<Vacancys>(Collections.Vacancy);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Vacancys>> SearchAllVacancyAsync()
            => await _collection.AsQueryable().Where(x => x.Activy.Equals(true))
                                .OrderByDescending(x => x.PostDate)
                                .ToListAsync();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        public async Task<Vacancys> SearchOneVacancySlugAsync(int slug)
        {
            Vacancys vaga = await _collection.AsQueryable()
                            .Where(x => x.Slug.Equals(slug))
                            .FirstOrDefaultAsync();

            return await SearchOneVacancyIdAsync(vaga.Id);
        }
            

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idResp"></param>
        /// <returns></returns>
        public async Task<Vacancys> SearchOneVacancyIdAsync(string idResp)
            => await _collection.AsQueryable()
                                .Where(x => x.Id.Equals(idResp) && x.Activy.Equals(true))
                                .FirstOrDefaultAsync();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="vaga"></param>
        /// <returns></returns>
        public async Task NewVacancyAsync(Vacancys vaga)
        {

            int slug = await CountVacancyAsync();

            vaga.Slug = slug + 1;

            await _collection.InsertOneAsync(vaga);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="vaga"></param>
        /// <param name="editions"></param>
        /// <returns></returns>
        public async Task ChangeOneVacancyAsync(Vacancys vaga,Vacancys editions)
        {

            vaga.Company = editions.Company;
            vaga.Email = editions.Email;
            vaga.Phone = editions.Phone;
            vaga.Title = editions.Title;
            vaga.Status = editions.Status;
            vaga.City = editions.City;
            vaga.InformationVacancy = editions.InformationVacancy;

            await _collection.ReplaceOneAsync(x => x.Id.Equals(vaga.Id), vaga);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="vaga"></param>
        /// <returns></returns>
        public async Task DeleteOneVacancyAsync(Vacancys vaga)
        {
            if(vaga.Activy)
                vaga.Activy = false;

            await _collection.ReplaceOneAsync(x => x.Id.Equals(vaga.Id), vaga);
        }

        

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private async Task<int> CountVacancyAsync()
            => await _collection.AsQueryable().CountAsync();

    }
}
