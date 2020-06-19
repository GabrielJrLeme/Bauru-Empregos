using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace BauruEmpregosBack.Models.Database
{
    public class UserClient : UserLogin
    {

        [BsonElement("Vacancies")]
        public List<Vacancy> Vacancies { get; set; } = new List<Vacancy>();


        public void AddVacancy(Vacancy vacancy)
            => Vacancies.Add((vacancy));

        public void RemoveVacancy(Vacancy vacancy)
            => Vacancies.Remove(vacancy);
    }
}
