using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json.Converters;
using System;
using System.Text.Json.Serialization;

namespace BauruEmpregosBack.Models.Database
{
    public class UserLogin
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }


        [BsonElement("Name")]
        [BsonRepresentation(BsonType.String)]
        public string Name { get; set; }


        [BsonElement("Login")]
        [BsonRepresentation(BsonType.String)]
        public string Login { get; set; }


        [BsonElement("Email")]
        [BsonRepresentation(BsonType.String)]
        public string Email { get; set; }


        [BsonElement("Password")]
        [BsonRepresentation(BsonType.String)]
        [JsonIgnore]
        public string Password { get; set; }


        [BsonElement("Phone")]
        [BsonRepresentation(BsonType.String)]
        public string Phone { get; set; }


        [BsonElement("Role")]
        [BsonRepresentation(BsonType.String)]
        public string Role { get; set; }


        [BsonElement("Activy")]
        [BsonRepresentation(BsonType.Boolean)]
        public bool Activy { get; set; } = true;


        [BsonElement("Token")]
        [BsonRepresentation(BsonType.String)]
        public string Token { get; set; } = null;


        [BsonElement("CreateDate")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreateDate { get;} = DateTime.Now;


        [BsonElement("DateLeftLogin")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime DateLeftLogin { get; set; }

    }
}
