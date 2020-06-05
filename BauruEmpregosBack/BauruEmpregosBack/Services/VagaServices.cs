using BauruEmpregosBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BauruEmpregosBack.Services
{
    public class VagaServices
    {

        private List<Vagas> _ListVagas;

        public List<Vagas> ListAllVagas()
        {
            _ListVagas = new List<Vagas>()
            {
                new Vagas(){Activy = true, Empresa = "Empresa1", Mensagem = "vaga1", Id = "1"},
                new Vagas(){Activy = true, Empresa = "Empresa2", Mensagem = "vaga2", Id = "2"},
                new Vagas(){Activy = true, Empresa = "Empresa3", Mensagem = "vaga3", Id = "3"},
                new Vagas(){Activy = true, Empresa = "Empresa4", Mensagem = "vaga4", Id = "4"}
            };

            return _ListVagas;
    }


    }
}
