using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BauruEmpregosBack.Models
{
    public class Solicitation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public List<Vacancy> Vacancys { get; set; } = new List<Vacancy>();

        public DateTime DatePublication { get; set; } = DateTime.Now;

        public bool Activy { get; set; } = true;


        public void AddVacancy(Vacancy vacancys)
        {
            Vacancys.Add(vacancys);
        }

        public void RemoveVacancy(Vacancy vacancys)
        {
            Vacancys.Remove(vacancys);
        }

        public int TotalVacancys()
        {
            return Vacancys.Count();    
        }

    }
}
