using Comseg.DTO.Request.Role;
using Comseg.DTO.Response;
using Comseg.Entities.Complex;
using Comseg.Entities.Helpers;
using Comseg.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Comseg.API.Controllers
{
    [Route(Constants.DefaultRoute)]
    [ApiController]
    [Authorize]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _service;

        public RolesController(IRoleService service)
        {
            _service = service;
        }
        [HttpGet]
        [ProducesResponseType(typeof(BaseResponseEntity<ICollection<RoleInfo?>>), 200)]
        public async Task<IActionResult> Get()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Sid);
            if (userId == null) return Unauthorized();

            var lst = await _service.GetCollectionAsync();
            return Ok(lst);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(BaseResponseEntity<RoleInfo?>), 200)]
        [ProducesResponseType(typeof(BaseResponseEntity<RoleInfo?>), 404)]
        public async Task<IActionResult> Get(int id)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Sid);
            if (userId == null) return Unauthorized();

            var lst = await _service.GetByIdAsync(id);
            if (lst.ResponseResult == null) return NotFound(lst);
            return Ok(lst);
        }

        [HttpPost]
        [ProducesResponseType(typeof(BaseResponseEntity<int>), 201)]
        [ProducesResponseType(typeof(BaseResponseEntity<int>), 400)]
        public async Task<IActionResult> Post(DtoRole request)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Sid);
            if (userId == null) return Unauthorized();

            var response = await _service.CreateAsync(request,userId.Value);
            return Created($"api/Genres/{response.ResponseResult}", response);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(BaseResponse), 200)]
        [ProducesResponseType(typeof(BaseResponse), 400)]
        public async Task<IActionResult> Put(int id, DtoRole request)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Sid);
            if (userId == null) return Unauthorized();

            var response = await _service.UpdateAsync(id, request, userId.Value);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(typeof(BaseResponse), 200)]
        [ProducesResponseType(typeof(BaseResponse), 400)]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Sid);
            if (userId == null) return Unauthorized();

            var response = await _service.DeleteAsync(id);
            return Ok(response);
        }
    }
}
