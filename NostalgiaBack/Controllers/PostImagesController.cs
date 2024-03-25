using Core.DTOs;
using Core.Interfaces;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace NostalgiaBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostImagesController : ControllerBase
    {
        private readonly IPostImageService _postImagesService;

        public PostImagesController(IPostImageService postImagesService)
        {
            _postImagesService = postImagesService;
        }
        [HttpPost("CreateImage")]
        public async Task<IActionResult> CreateImage(IFormFile ImageFile)
        {
            var result = await _postImagesService.CreateImageAsync(ImageFile);
            return Ok(result);
        }
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(PostImageDTO tag)
        {
            var existingImage = await _postImagesService.GetByIdAsync(tag.Id);
            if (existingImage == null)
            {
                return NotFound();
            }

            await _postImagesService.EditAsync(tag);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)  //default FromQuery   => ~/api/movies?id=2   //FromRoute => ~/api/movies/2
        {
            return Ok(await _postImagesService.GetByIdAsync(id));
        }
    }
}
