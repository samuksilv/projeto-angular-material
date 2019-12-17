namespace Portal.Domain.Dtos.Request
{
    public class PaginatedRequest
    {
        /// <summary>
        /// Número da página
        /// </summary>
        /// <value></value>
        public int Page { get; set; }

        /// <summary>
        /// Quantidade de registros por página
        /// </summary>
        /// <value></value>
        public int PageSize { get; set; } = 10;
    }
}