using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace BauruEmpregosBack.Models
{
    public class Vagas
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Company { get; set; }

        public string Title { get; set; }

        public long Slug { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string InformationVacancy { get; set; }

        public string City { get; set; }

        public bool Activy { get; set; } = true;

        public bool Status { get; set; } = true;

        public DateTime PostDate { get; set; } = DateTime.Now;

    }
}
