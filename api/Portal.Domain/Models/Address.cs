namespace Portal.Domain.Models {

    /// <summary>
    /// Endereço
    /// </summary>
    public class Address : BaseModel {

        /// <summary>
        /// Rua 
        /// </summary>
        /// <value></value>
        public string Street { get; set; }

        /// <summary>
        /// número 
        /// </summary>
        /// <value></value>
        public int Number { get; set; }

        /// <summary>
        /// complemento
        /// </summary>
        /// <value></value>
        public string Complement { get; set; }

        /// <summary>
        /// bairro
        /// </summary>
        /// <value></value>
        public string Neighborhood { get; set; }

        /// <summary>
        /// cidade
        /// </summary>
        /// <value></value>
        public string City { get; set; }

        /// <summary>
        /// UF
        /// </summary>
        /// <value></value>
        public string UF { get; set; }

        /// <summary>
        /// Empresa
        /// </summary>
        /// <value></value>
        public Company Company { get; set; }
    }
}