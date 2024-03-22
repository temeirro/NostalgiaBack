using Core.DTOs;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace NostalgiaBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostsService _postsService;
        public PostsController(IPostsService postsService)
        {
            _postsService = postsService;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreatePost(PostCreateDTO createProductDTO)
        {
            await _postsService.CreateAsync(createProductDTO);
            return Ok();
        }
    }
}
