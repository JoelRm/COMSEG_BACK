using Comseg.DTO.Response;
using Comseg.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Comseg.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PagesController : ControllerBase
    {
        private readonly IPageService _repository;

        public PagesController(IPageService repository)
        {
            _repository = repository;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(BaseResponsePages<PagesResponse>), 200)]
        [ProducesResponseType(typeof(BaseResponsePages<PagesResponse>), 400)]
        public async Task<IActionResult> Get(int id)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Sid);
            if (userId == null) return Unauthorized();

            var response = new BaseResponsePages<PagesResponse>();
            response = await _repository.GetCollectionAsync(id);
            return Ok(response);
        }

    }
}
