using System.Collections.Generic;
using System.Threading.Tasks;
using Portal.Domain.Dtos.Request;
using Portal.Domain.Dtos.Response;
using Portal.Domain.Models;

namespace Portal.Domain.Contracts.BusinessLogic
{
    public interface ISegmentService
    {
        Task<SegmentResponse> CreateAsync(SegmentCreateUpdateRequest request);
        Task<SegmentResponse> UpdateAsync( string id, SegmentCreateUpdateRequest request);
        Task DeleteAsync( string id);
        Task<Segment> GetSegmentById(string id);
        Task<List<SegmentResponse>> GetWithFilter( SegmentFilterRequest request);
        Task<PaginatedResponse<SegmentResponse>> GetPaginatedWithFilter( SegmentFilterPaginatedRequest request);
    }
}