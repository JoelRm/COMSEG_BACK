using Comseg.DTO.Request;
using Comseg.DTO.Response;
using Comseg.Entities.Complex;
using Comseg.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Comseg.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(BaseResponseEntity<ICollection<CategoryInfo?>>), 200)]
        public async Task<IActionResult> Get()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Sid);
            if (userId == null) return Unauthorized();

            var lst = await _service.GetCollectionAsync();
            return Ok(lst);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(BaseResponseEntity<CategoryInfo?>), 200)]
        [ProducesResponseType(typeof(BaseResponseEntity<CategoryInfo?>), 404)]
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
        public async Task<IActionResult> Post(DtoCategory request)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Sid);
            if (userId == null) return Unauthorized();

            var response = await _service.CreateAsync(request, userId.Value);
            return Created($"api/Category/{response.ResponseResult}", response);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(BaseResponse), 200)]
        [ProducesResponseType(typeof(BaseResponse), 400)]
        public async Task<IActionResult> Put(int id, DtoCategory request)
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
            var response = await _service.DeleteAsync(id);
            return Ok(response);
        }
    }
}
