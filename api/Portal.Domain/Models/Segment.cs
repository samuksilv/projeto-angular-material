using System.Collections.Generic;

namespace Portal.Domain.Models {
    /// <summary>
    /// Segmento
    /// </summary>
    public class Segment : BaseModel {
        /// <summary>
        /// Descrição do Segmento
        /// </summary>
        /// <value></value>        
        public string Description { get; set; }

        /// <summary>
        /// Empresas
        /// </summary>
        /// <value></value>
        public List<Company> Companies { get; set; }

    }
}