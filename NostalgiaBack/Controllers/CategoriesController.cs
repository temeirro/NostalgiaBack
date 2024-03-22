using Core.DTOs;
using Core.Interfaces;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace NostalgiaBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;
        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpGet] 
        public async Task<IActionResult> Get()
        {
            return Ok(await _categoriesService.GetAllAsync());
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CategoryCreateDTO category)
        {
            await _categoriesService.CreateAsync(category);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoriesService.DeleteAsync(id);
            return Ok();
        }
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(CategoryDTO category)
        {
            await _categoriesService.EditAsync(category);
            return Ok();
        }
    }
}
