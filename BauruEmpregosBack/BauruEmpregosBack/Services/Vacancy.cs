using BauruEmpregosBack.Data;
using BauruEmpregosBack.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BauruEmpregosBack.Services
{
    public class Vacancy
    {

        private readonly IMongoCollection<Vacancys> _collection;


        public Vacancy(IStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<Vacancys>(settings.CollectionName);
        }




        public async Task<List<Vacancys>> SearchAllVacancyAsync()
            => await _collection.AsQueryable().Where(x => x.Activy.Equals(true))
                                .OrderByDescending(x => x.PostDate)
                                .ToListAsync();

        public async Task<Vacancys> SearchOneVacancySlugAsync(int slug)
        {
            Vacancys vaga = await _collection.AsQueryable()
                            .Where(x => x.Slug.Equals(slug))
                            .FirstOrDefaultAsync();

            return await SearchOneVacancyIdAsync(vaga.Id);
        }
            


        public async Task<Vacancys> SearchOneVacancyIdAsync(string idResp)
            => await _collection.AsQueryable().Where(x => x.Id.Equals(idResp) && x.Activy.Equals(true)).FirstOrDefaultAsync();

        public async Task NewVacancyAsync(Vacancys vaga)
        {

            int slug = await CountVacancyAsync();

            vaga.Slug = slug + 1;

            await _collection.InsertOneAsync(vaga);
        }


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

        public async Task DeleteOneVacancyAsync(Vacancys vaga)
        {
            if(vaga.Activy)
                vaga.Activy = false;

            await _collection.ReplaceOneAsync(x => x.Id.Equals(vaga.Id), vaga);
        }

        
        private async Task<int> CountVacancyAsync()
            => await _collection.AsQueryable().CountAsync();

    }
}
