using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace BauruEmpregosBack.Models
{

    /// <summary>
    /// Classe que define os atributos de uma vaga
    /// </summary>
    public class Vagas
    {

        /// <value>
        /// ID => propriedade identificadora da vaga
        /// </value>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <value>
        /// Company => propriedade que carrega a empresa referente
        /// </value>
        public string Company { get; set; }

        /// <value>
        /// Title => propriedade que carrega o titulo da vaga
        /// </value>
        public string Title { get; set; }

        /// <value>
        /// Slug => propriedade que carrega URL de identificação da vaga 
        /// </value>
        public int Slug { get; set; }

        /// <value>
        /// Email => propriedade que carrega o Email do solicitante
        /// </value>
        public string Email { get; set; }

        /// <value>
        /// Phone => propriedade de contato com o solicitante
        /// </value>
        public string Phone { get; set; }

        /// <value>
        /// InformationVacancy => propriedade que contém as informações referente a vaga
        /// </value>
        public string InformationVacancy { get; set; }

        /// <value>
        /// City => propriedade que contém a cidade da oportunidade
        /// </value>
        public string City { get; set; }

        /// <value>
        /// Activy => propriedade que define se a vaga está ou não ativa no sistema
        /// </value>
        public bool Activy { get; set; } = true;

        /// <value>
        /// Status => propriedade que define se a vaga está ou não em aberto
        /// </value>
        public bool Status { get; set; } = true;

        /// <value>
        /// PostDate => propriedade que define a data de postagem da vaga
        /// </value>
        public DateTime PostDate { get; set; } = DateTime.Now;

    }
}
