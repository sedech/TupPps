using BusnessService.IService;
using BusnessService.Service;
using BussnessEntities;
using DataModels.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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


        /*
          permite crear una nueva categoría. Recibe un objeto CategoryToCreateBe en el cuerpo de la solicitud. 
       Llama al método Create del servicio de categorías pasando este objeto y
        devuelve una respuesta exitosa (200 OK) con el resultado de la creación de la categoría.
         */

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Vendedor")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryToCreateBe category)
        {
            return Ok(await _categoryService.Create(category));
        }

        /*
         permite obtener una categoría específica por su ID. Toma un parámetro IdCategory en la URL.
        Llama al método GetById del servicio de categorías pasando este ID y 
        devuelve una respuesta exitosa (200 OK) con los detalles de la categoría obtenida.
         */

        [HttpGet]
        [Route("getCategory/{IdCategory}")]
        public async Task<IActionResult> GetCategory(int IdCategory)
        {

            return Ok(await _categoryService.GetById(IdCategory));
        }

        /*
         permite actualizar una categoría existente. 
        Recibe un objeto CategoryBe en el cuerpo de la solicitud que contiene los nuevos datos de la categoría. 
        Llama al método Update del servicio de categorías pasando este objeto y 
        devuelve una respuesta exitosa (200 OK) con el resultado de la actualización de la categoría.
         */

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Vendedor")]
        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryBe category)
        {
            return Ok(await _categoryService.Update(category));
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Vendedor")]
        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] int state)
        {
            var categories = await _categoryService.GetAll(state);
            return Ok(categories);
        }


    }
}
