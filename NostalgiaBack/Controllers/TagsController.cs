using Core.DTOs;
using Core.Interfaces;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace NostalgiaBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagsService _tagsService;
        public TagsController(ITagsService tagsService)
        {
            _tagsService = tagsService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _tagsService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)  //default FromQuery   => ~/api/movies?id=2   //FromRoute => ~/api/movies/2
        {
            return Ok(await _tagsService.GetByIdAsync(id));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(TagCreateDTO tag)
        {
            await _tagsService.CreateAsync(tag);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingTag = await _tagsService.GetByIdAsync(id);
            if (existingTag == null)
            {
                return NotFound();
            }

            await _tagsService.DeleteAsync(id);
            return Ok();
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(TagDTO tag)
        {
            // Check if the tag with the provided id exists
            var existingTag = await _tagsService.GetByIdAsync(tag.Id);
            if (existingTag == null)
            {
                return NotFound(); // Return NotFound if the tag doesn't exist
            }

            await _tagsService.EditAsync(tag);
            return Ok();
        }
    }
}
