using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Domain.Contracts.BusinessLogic;
using Portal.Domain.Contracts.Repositories;
using Portal.Domain.Dtos.Request;
using Portal.Domain.Dtos.Response;
using Portal.Domain.Models;

namespace Portal.Domain.BusinessLogic {
    public class SegmentService : ISegmentService {

        private readonly ISegmentRepository _segmentRepository;

        public SegmentService (ISegmentRepository segmentRepository) {
            _segmentRepository = segmentRepository;
        }

        public async Task<SegmentResponse> CreateAsync (SegmentCreateUpdateRequest request) {

            var model = (Segment) request;

            model.Id = Guid.NewGuid ();

            var result = await _segmentRepository.SaveAsync (model);

            var response = (SegmentResponse) result;

            await _segmentRepository.SaveChangesAsync ();

            return response;
        }

        public async Task DeleteAsync (string id) {
            Segment segment = await GetSegmentById (id);

            await _segmentRepository.DeleteAsync (segment);

            await _segmentRepository.SaveChangesAsync ();
        }

        public async Task<Segment> GetSegmentById (string id) {
            if (!Guid.TryParse (id, out Guid uid))
                throw new Exception ("Id inválido.");

            Segment segment = await _segmentRepository.GetByIdAsync (uid);

            if (segment == null)
                throw new Exception ("Segmento não encontrado.");

            return segment;
        }

        public async Task<PaginatedResponse<SegmentResponse>> GetPaginatedWithFilter (SegmentFilterPaginatedRequest request) {

            IEnumerable<Segment> result = await _segmentRepository.GetPaginatedWithFilterAsync (request.Description, request.Page, request.PageSize);
            int totalRegisters = await _segmentRepository.Count (request.Description);

            PaginatedResponse<SegmentResponse> response = new PaginatedResponse<SegmentResponse> {
                Data = result?.Select (x => (SegmentResponse) x)?.ToList (),
                TotalItems = totalRegisters,
                TotalPages = (long) Math.Ceiling ((double) totalRegisters / (double) request.PageSize)
            };

            return response;
        }

        public async Task<List<SegmentResponse>> GetWithFilter (SegmentFilterRequest request) {

            IEnumerable<Segment> result;
            if (string.IsNullOrEmpty (request.Description))
                result = await _segmentRepository.GetAllAsync ();
            else
                result = await _segmentRepository.GetFilterByDescriptionAsync (request.Description);

            var response = result?.Select (x => (SegmentResponse) x)?.ToList ();

            return response;
        }

        public async Task<SegmentResponse> UpdateAsync (string id, SegmentCreateUpdateRequest request) {

            Segment segment = await GetSegmentById (id);

            segment.Description = request.Description;

            var result = await _segmentRepository.UpdateAsync (segment);

            var response = (SegmentResponse) result;

            await _segmentRepository.SaveChangesAsync ();

            return response;
        }
    }
}