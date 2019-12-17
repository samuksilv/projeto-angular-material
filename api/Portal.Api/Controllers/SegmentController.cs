using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portal.Domain.Contracts.BusinessLogic;
using Portal.Domain.Dtos;
using Portal.Domain.Dtos.Request;

namespace Portal.Api.Controllers {

    [ApiVersion ("1")]
    [Route ("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class SegmentController : ControllerBase {

        private ISegmentService _segmentService;

        public SegmentController (ISegmentService segmentService) {
            _segmentService = segmentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create ([FromBody] SegmentCreateUpdateRequest request) {

            var response = await _segmentService.CreateAsync (request);
            return Created (response.Id.ToString (), response);
        }

        [HttpPut ("{id}")]
        public async Task<IActionResult> Update ([FromRoute] string id, [FromBody] SegmentCreateUpdateRequest request) {

            var response = await _segmentService.UpdateAsync (id, request);
            return Ok (response);
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> Delete ([FromRoute] string id) {

            await _segmentService.DeleteAsync (id);
            return NoContent ();
        }

        [HttpGet]
        public async Task<IActionResult> GetWithFilter ([FromQuery] SegmentFilterRequest request) {

            var response = await _segmentService.GetWithFilter (request);
            return Ok (response);
        }

        [HttpGet ("filter")]
        public async Task<IActionResult> GetPaginatedWithFilter ([FromQuery] SegmentFilterPaginatedRequest request) {

            var response = await _segmentService.GetPaginatedWithFilter (request);
            return Ok (response);
        }

    }
}