

using BusnessService.IService;
using BussnessEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TupPps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }


        /*
         permite crear un nuevo producto. Recibe un objeto ProductToCreateBe en el cuerpo de la solicitud que contiene 
        los datos del producto a crear. Llama al método Create del servicio de productos pasando este objeto
        y devuelve una respuesta exitosa (200 OK) con el resultado de la creación del producto.
         */

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Vendedor")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct( ProductToCreateBe product)
        {
            return Ok(await _productService.Create(product));
        }

        /*
          permite eliminar un producto existente. Recibe un parámetro IdProduct desde la consulta. 
        Llama al método Delete del servicio de productos pasando este ID del producto y 
        devuelve una respuesta exitosa (200 OK) con el resultado de la eliminación del producto.
         */

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct([FromQuery] int IdProduct)
        {
            return Ok(await _productService.Delete(IdProduct));
        }

        /*
          permite obtener un producto específico por su ID. Toma un parámetro IdProduct en la URL. 
        Llama al método GetById del servicio de productos pasando este ID 
        y devuelve una respuesta exitosa (200 OK) con los detalles del producto obtenido.
         */

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Vendedor")]
        [HttpGet]
        [Route("getProduct/{IdProduct}")]
        public async Task<IActionResult> GetProduct(int IdProduct)
        {

            return Ok(await _productService.GetById(IdProduct));
        }

        /*
         permite actualizar un producto existente. Recibe un objeto ProductBe en el cuerpo de la solicitud que contiene los nuevos datos del producto. 
        Llama al método Update del servicio de productos pasando este objeto y 
        devuelve una respuesta exitosa (200 OK) con el resultado de la actualización del producto.
         */

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Vendedor")]
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductBe product)
        {
            return Ok(await _productService.Update(product));
        }

    }
}