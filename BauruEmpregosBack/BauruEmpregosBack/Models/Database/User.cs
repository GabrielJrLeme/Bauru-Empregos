using BauruEmpregosBack.Models.Enum;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BauruEmpregosBack.Models.Database
{
    public class User
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }



        [BsonElement("Name")]
        [BsonRepresentation(BsonType.String)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "É obrigatório possuir um nome")]
        public string Name { get; set; }



        [BsonElement("Login")]
        [BsonRepresentation(BsonType.String)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "É obrigatório possuir um login")]
        public string Login { get; set; }



        [BsonElement("Email")]
        [BsonRepresentation(BsonType.String)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "É obrigatório possuir um email")]
        public string Email { get; set; }



        [JsonIgnore]
        [BsonRequired]
        [BsonElement("Password")]
        [BsonRepresentation(BsonType.String)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "É obrigatório possuir uma senha")]
        public string Password { get; set; }



        [BsonElement("Activy")]
        [BsonRepresentation(BsonType.Boolean)]
        public bool Activy { get; set; } = true;



        [BsonElement("Token")]
        [BsonRepresentation(BsonType.String)]
        public string Token { get; set; } = null;



        [BsonElement("CreateDate")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreateDate { get; } = DateTime.Now;



        [BsonElement("DateLeftLogin")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? DateLeftLogin { get; set; }



        [BsonElement("Vacancies")]
        [JsonIgnore]
        public GroupVacancies GroupVacancies { get; set; }



        [BsonElement("IdGroupVacancies")]
        [BsonRepresentation(BsonType.String)]
        public string IdGroupVacancies { get; set; }



        [BsonElement("Role")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Role Role { get; set; }


    }
}
