using Comseg.DTO.Request.SubMenu;
using Comseg.DTO.Response;
using Comseg.Entities.Complex;
using Comseg.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Comseg.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubMenusController : ControllerBase
    {
        private readonly ISubMenuService _service;

        public SubMenusController(ISubMenuService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(BaseResponseEntity<ICollection<SubMenuInfo?>>), 200)]
        public async Task<IActionResult> Get()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Sid);
            if (userId == null) return Unauthorized();

            var lst = await _service.GetCollectionAsync();
            return Ok(lst);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(BaseResponseEntity<SubMenuInfo?>), 200)]
        [ProducesResponseType(typeof(BaseResponseEntity<SubMenuInfo?>), 404)]
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
        public async Task<IActionResult> Post(DtoSubMenu request)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Sid);
            if (userId == null) return Unauthorized();

            var response = await _service.CreateAsync(request,userId.Value);
            return Created($"api/Genres/{response.ResponseResult}", response);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(BaseResponse), 200)]
        [ProducesResponseType(typeof(BaseResponse), 400)]
        public async Task<IActionResult> Put(int id, DtoSubMenu request)
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
