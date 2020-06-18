using BauruEmpregosBack.Models.Enum;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BauruEmpregosBack.Models.Database
{
    public class User : User
    {

        [BsonElement("Role")]
        [BsonRepresentation(BsonType.String)]
        public override Role Role { get; set;} = Role.user;


        public List<Vacancy> Vacancys { get; set; } = new List<Vacancy>();

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
