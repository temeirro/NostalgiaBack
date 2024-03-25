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
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)  //default FromQuery   => ~/api/movies?id=2   //FromRoute => ~/api/movies/2
        {
            return Ok(await _categoriesService.GetByIdAsync(id));
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CategoryCreateDTO category)
        {
            await _categoriesService.CreateAsync(category);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingCategory = await _categoriesService.GetByIdAsync(id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            await _categoriesService.DeleteAsync(id);
            return Ok();
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(CategoryDTO category)
        {
            var existingCategory = await _categoriesService.GetByIdAsync(category.Id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            await _categoriesService.EditAsync(category);
            return Ok();
        }
    }
}
