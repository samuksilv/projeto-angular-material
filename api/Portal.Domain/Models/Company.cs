using System;
using System.Collections.Generic;

namespace Portal.Domain.Models {

    /// <summary>
    /// Empresa
    /// </summary>
    public class Company : BaseModel {

        /// <summary>
        /// CNPJ
        /// </summary>
        /// <value></value>
        public string DocumentCnpj { get; set; }

        /// <summary>
        /// Razão Social
        /// </summary>
        /// <value></value>
        public string CorporateName { get; set; }

        /// <summary>
        /// Nome Fantasia
        /// </summary>
        /// <value></value>
        public string FantasyName { get; set; }

        /// <summary>
        /// Id do Segmento
        /// </summary>
        /// <value></value>
        public Guid SegmentId { get; set; }

        /// <summary>
        /// Id do Logo da empresa
        /// </summary>
        /// <value></value>
        public Guid CompanyLogoId { get; set; }

        /// <summary>
        /// Id dDo endereço
        /// </summary>
        /// <value></value>
        public Guid AddressId { get; set; }

        /// <summary>
        /// Logo da Empresa
        /// </summary>
        /// <value></value>
        public CompanyLogo CompanyLogo { get; set; }

        /// <summary>
        /// Segmento
        /// </summary>
        /// <value></value>
        public Segment Segment { get; set; }

        /// <summary>
        /// Contatos
        /// </summary>
        /// <value></value>
        public List<Contact> Contacts { get; set; }

        /// <summary>
        /// Endereço
        /// </summary>
        /// <value></value>
        public Address Address { get; set; }

    }
}