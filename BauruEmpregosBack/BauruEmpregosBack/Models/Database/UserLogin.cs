using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
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

<<<<<<<< HEAD:BauruEmpregosBack/BauruEmpregosBack/Models/Database/UserLogin.cs

========
        [JsonIgnore]
>>>>>>>> ec93838cfc6a85fd5ba9bdc42388ef571a3abff2:BauruEmpregosBack/BauruEmpregosBack/Models/Database/User.cs
        [BsonElement("Password")]
        [BsonRepresentation(BsonType.String)]
        [JsonIgnore]
        public string Password { get; set; }


        [BsonElement("Phone")]
        [BsonRepresentation(BsonType.String)]
        public string Phone { get; set; }


        [BsonElement("Role")]
        [BsonRepresentation(BsonType.String)]
<<<<<<<< HEAD:BauruEmpregosBack/BauruEmpregosBack/Models/Database/UserLogin.cs
        public string Role { get; set; }

========
        public virtual Role Role { get; set; }
>>>>>>>> ec93838cfc6a85fd5ba9bdc42388ef571a3abff2:BauruEmpregosBack/BauruEmpregosBack/Models/Database/User.cs

        [BsonElement("Activy")]
        [BsonRepresentation(BsonType.Boolean)]
        public bool Activy { get; set; } = true;

<<<<<<<< HEAD:BauruEmpregosBack/BauruEmpregosBack/Models/Database/UserLogin.cs

========
>>>>>>>> ec93838cfc6a85fd5ba9bdc42388ef571a3abff2:BauruEmpregosBack/BauruEmpregosBack/Models/Database/User.cs
        [BsonElement("Token")]
        [BsonRepresentation(BsonType.String)]
        public string Token { get; set; } = null;

<<<<<<<< HEAD:BauruEmpregosBack/BauruEmpregosBack/Models/Database/UserLogin.cs

========
>>>>>>>> ec93838cfc6a85fd5ba9bdc42388ef571a3abff2:BauruEmpregosBack/BauruEmpregosBack/Models/Database/User.cs
        [BsonElement("CreateDate")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreateDate { get;} = DateTime.Now;


        [BsonElement("DateLeftLogin")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime DateLeftLogin { get; set; }

    }
}
