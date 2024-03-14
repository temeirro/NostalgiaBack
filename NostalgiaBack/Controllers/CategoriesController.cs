using Core.DTOs;
using Core.Interfaces;
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
    }
}
