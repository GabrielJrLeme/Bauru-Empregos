using BauruEmpregosBack.Models.Enum;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BauruEmpregosBack.Models.Database
{
    public class UserAdmin : User
    {

        [BsonElement("Role")]
        [BsonRepresentation(BsonType.String)]
        public override Role Role { get; set; } = Role.admin;

    }
}
