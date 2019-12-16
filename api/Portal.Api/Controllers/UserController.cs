using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portal.Domain.BusinessLogic;
using Portal.Domain.Contracts.BusinessLogic;
using Portal.Domain.Dtos.Request;

namespace Portal.Api.Controllers {

    [ApiVersion ("1")]
    [Route ("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {

        private readonly IUserService _userService;

        public UserController (IUserService userService) {
            _userService = userService;
        }

        [HttpPost ("register")]
        public async Task<IActionResult> RegisterAsync ([FromBody] UserRegisterRequest request) {
            var response = await _userService.RegisterAsync (request);

            return Created( response.Id.ToString(), response );
        }

        [HttpGet ("{id}")]
        [Authorize]
        public async Task<IActionResult> GetByIdAsync ([FromRoute] string id) {
            var response = await _userService.GetByIdAsync (id);

            return Ok (response);
        }

        [HttpPost ("login")]
        public async Task<IActionResult> LoginAsync ([FromBody] UserLoginRequest request) {
            var response = await _userService.LoginAsync (request);

            return Ok (response);
        }

    }
}