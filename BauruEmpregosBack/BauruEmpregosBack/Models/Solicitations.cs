using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BauruEmpregosBack.Models
{
    public class Solicitations
    {

        public string Id { get; set; }

        public List<Vacancys> Vacancys { get; set; } = new List<Vacancys>();

        public DateTime DatePublication { get; set; } = DateTime.Now;

        public bool Activy { get; set; } = true;


        public void AddVacancy(Vacancys vacancys)
        {
            Vacancys.Add(vacancys);
        }

        public void RemoveVacancy(Vacancys vacancys)
        {
            Vacancys.Remove(vacancys);
        }

        public int TotalVacancys()
        {
            return Vacancys.Count();    
        }

    }
}
