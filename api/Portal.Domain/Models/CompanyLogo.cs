namespace Portal.Domain.Models {

    /// <summary>
    /// Logo da empresa
    /// </summary>
    public class CompanyLogo: BaseModel {

        /// <summary>
        /// Logo
        /// </summary>
        /// <value></value>
        public byte[] Logo { get; set; }

        /// <summary>
        /// Company
        /// </summary>
        /// <value></value>
        public Company Company { get; set; }
    }
}