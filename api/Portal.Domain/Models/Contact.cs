using System;
using Portal.Domain.Enums;

namespace Portal.Domain.Models {

    /// <summary>
    /// Contato
    /// </summary>
    public class Contact : BaseModel {

        /// <summary>
        /// Tipo de contato
        /// </summary>
        /// <value></value>
        public ContactTypeEnum ContactType { get; set; }

        /// <summary>
        /// Valor do Contato
        /// </summary>
        /// <value></value>
        public string ContactValue { get; set; }

        /// <summary>
        /// Id da Empresa
        /// </summary>
        /// <value></value>
        public Guid CompanyId { get; set; }

        /// <summary>
        /// Empresa
        /// </summary>
        /// <value></value>
        public Company Company { get; set; }
    }
}