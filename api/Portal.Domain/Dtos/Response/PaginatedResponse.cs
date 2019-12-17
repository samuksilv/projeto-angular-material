using System.Collections.Generic;

namespace Portal.Domain.Dtos.Response
{
    public class PaginatedResponse<T> where T : class
    {

        

        /// <summary>
        /// Dados
        /// </summary>
        /// <value></value>
        public List<T> Data { get; set; }
        
        /// <summary>
        /// Quantidade de páginas
        /// </summary>
        /// <value></value>
        public long TotalPages { get; set; }

        /// <summary>
        /// Quantidade total de items
        /// </summary>
        /// <value></value>
        public long TotalItems { get; set; }
    }
}