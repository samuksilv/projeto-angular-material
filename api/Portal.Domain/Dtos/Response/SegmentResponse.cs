using System;
using Portal.Domain.Models;

namespace Portal.Domain.Dtos.Response
{
    public class SegmentResponse
    {

        /// <summary>
        /// Id do Segmento
        /// </summary>
        /// <value></value>
        public Guid Id { get; set; }

        /// <summary>
        /// Descrição do segmento
        /// </summary>
        /// <value></value>
        public string Description { get; set; }

        /// <summary>
        /// Data de Criação
        /// </summary>
        /// <value></value>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Data de atualização 
        /// </summary>
        /// <value></value>
        public DateTime? UpdatedAt { get; set; }

        public static explicit operator SegmentResponse(Segment model)
        {
            return new SegmentResponse{
                Id = model.Id,
                CreatedAt= model.CreatedAt,
                UpdatedAt= model.UpdatedAt,
                Description= model.Description,
            };
        }
    }
}