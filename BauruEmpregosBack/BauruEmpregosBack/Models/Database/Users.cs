using System;

namespace BauruEmpregosBack.Models.Database
{
    public class Users
    {

        public string Id { get; set; }

        public string Name { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public bool Activy { get; set; } = true;

        public DateTime CreateDate { get; protected set; } = DateTime.Now;

        public DateTime DateLeftLogin { get; set; }

    }
}
