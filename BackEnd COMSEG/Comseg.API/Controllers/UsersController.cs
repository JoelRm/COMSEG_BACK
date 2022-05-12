using Comseg.DTO.Request;
using Comseg.DTO.Response;
using Comseg.Entities.Helpers;
using Comseg.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Comseg.API.Controllers
{
    [Route(Constants.DefaultRoute)]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IConfiguration _configuration;

        public UsersController(IUserService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        [HttpPost]
        [ProducesResponseType(typeof(BaseResponseLogin<UserLoginResponse>), 200)]
        [ProducesResponseType(typeof(BaseResponseLogin<UserLoginResponse>), 404)]
        public async Task<IActionResult> Post(DtoLogin request)
        {
            var response = new BaseResponseLogin<UserLoginResponse>();
            response = await _service.Login(request);
            
            if (response.UserResponse == null) return NotFound(response);

            return Ok(response);
        }
    }
}
