using System.Collections.Generic;
using System.Threading.Tasks;
using Portal.Domain.Models;

namespace Portal.Domain.Contracts.Repositories {
    public interface ISegmentRepository : IBaseRepository<Segment> {
        Task<IEnumerable<Segment>> GetAllAsync ();
        Task<IEnumerable<Segment>> GetFilterByDescriptionAsync (string description);
        Task<IEnumerable<Segment>> GetPaginatedWithFilterAsync (string description, int page, int pageSize);
        Task<int> Count(string description);     

    }
}