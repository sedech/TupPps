using BusnessService.IService;
using BusnessService.Service;
using BussnessEntities;
using DataModels.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TupPps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryToCreateBe category)
        {
            return Ok(await _categoryService.Create(category));
        }

        [HttpGet]
        [Route("getCategory/{IdCategory}")]
        public async Task<IActionResult> GetCategory(int IdCategory)
        {

            return Ok(await _categoryService.GetById(IdCategory));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryBe category)
        {
            return Ok(await _categoryService.Update(category));
        }
    }
}
