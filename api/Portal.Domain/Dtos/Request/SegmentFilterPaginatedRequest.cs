namespace Portal.Domain.Dtos.Request
{
    public class SegmentFilterPaginatedRequest: PaginatedRequest
    {
        /// <summary>
        /// Descrição do segmento
        /// </summary>
        /// <value></value>
        public string Description { get; set; }
    }
}