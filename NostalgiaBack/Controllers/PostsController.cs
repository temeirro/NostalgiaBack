using Core.DTOs;
using Core.Interfaces;
using Core.Services;
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
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _postsService.GetAllAsync());
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingPost = await _postsService.GetByIdAsync(id);
            if (existingPost == null)
            {
                return NotFound();
            }

            await _postsService.DeletePostByIDAsync(id);
            return Ok();
        }
    }
}
