using System;

namespace Portal.Domain.Models
{
    public class BaseModel
    {
        /// <summary>
        /// Identificador
        /// </summary>
        /// <value></value>
        public Guid Id { get; set; }

        /// <summary>
        /// Data de criação
        /// </summary>
        /// <value></value>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Data de atualização
        /// </summary>
        /// <value></value>
        public DateTime? UpdatedAt { get; set; }
    }
}