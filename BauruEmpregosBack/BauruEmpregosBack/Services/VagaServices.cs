using BauruEmpregosBack.Data;
using BauruEmpregosBack.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BauruEmpregosBack.Services
{
    public class VagaServices
    {

        private readonly IMongoCollection<Vagas> _collection;


        public VagaServices(IStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<Vagas>(settings.VacancyCollectionName);
        }




        public async Task<List<Vagas>> SearchAllVacancyAsync()
            => await _collection.Find(x => x.Activy.Equals(true)).ToListAsync();


        public async Task<Vagas> SearchOneVacancyAsync(string idResp)
            => await _collection.Find(x => x.Id.Equals(idResp) && x.Activy.Equals(true)).FirstOrDefaultAsync();

        public async Task NewVacancyAsync(Vagas vaga)
        {

            long slug = await CountVacancyAsync();

            vaga.Slug = slug + 1;

            await _collection.InsertOneAsync(vaga);
        }


        public async Task ChangeOneVacancyAsync(Vagas vaga,Vagas editions)
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

        public async Task DeleteOneVacancyAsync(Vagas vaga)
        {

            vaga.Activy = false;

            await _collection.ReplaceOneAsync(x => x.Id.Equals(vaga.Id), vaga);
        }

        
        private async Task<long> CountVacancyAsync()
            => await _collection.Find(x => x.Activy.Equals(true) || x.Activy.Equals(false)).CountDocumentsAsync();
            
    }
}
