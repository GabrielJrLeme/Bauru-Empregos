using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BauruEmpregosBack.Models.Database
{
    public class GroupVacancies
    {

        public string Id { get; set; }

        public List<Vacancy> Vacancies { get; set; } = new List<Vacancy>();

        public string IdUser { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

    }
}
