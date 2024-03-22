using Core.Interfaces;
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
    }
}
