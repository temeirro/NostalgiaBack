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

        [HttpPost("Create")]
        public async Task<IActionResult> Create(TagCreateDTO tag)
        {
            await _tagsService.CreateAsync(tag);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _tagsService.DeleteAsync(id);
            return Ok();
        }
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(TagDTO tag)
        {
            await _tagsService.EditAsync(tag);
            return Ok();
        }
    }
}
