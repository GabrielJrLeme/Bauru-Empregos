﻿using BauruEmpregosBack.Models.Database;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace BauruEmpregosBack.Models
{
    public class Vacancy
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }


        [BsonElement("UserClient")]
        public User User { get; set; }


        [BsonElement("Title")]
        [BsonRepresentation(BsonType.String)]
        public string Title { get; set; }


        [BsonElement("Slug")]
        [BsonRepresentation(BsonType.Int32)]
        public int Slug { get; set; }



        [BsonElement("InformationVacancy")]
        [BsonRepresentation(BsonType.String)]
        public string InformationVacancy { get; set; }



        [BsonElement("City")]
        [BsonRepresentation(BsonType.String)]
        public string City { get; set; }



        [BsonElement("Activy")]
        [BsonRepresentation(BsonType.String)]
        public bool Activy { get; set; } = true;



        [BsonElement("Status")]
        [BsonRepresentation(BsonType.String)]
        public bool Status { get; set; } = true;



        [BsonElement("PostDate")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime PostDate { get; set; } = DateTime.Now;



    }
}
