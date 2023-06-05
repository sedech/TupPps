
using BusnessService.Service;
using BussnessEntities;
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
                                                   
        [HttpGet]
        public async Task<IActionResult> GetAllProductAsync(int state, string name)
        {
            List<ProductBe> producto = await this._productService.GetAll(state,name);
            return Ok(producto);
        }


        [HttpPost]
        public async Task<IActionResult>  CreateProduct([FromBody] ProductBe product) 
        {
              return Ok(await _productService.Create(product));
        }

        [HttpDelete]
        public async Task<IActionResult>  DeleteProduct([FromQuery]int IdProduct) 
        {
               return Ok(await _productService.Delete(IdProduct));
        }

        [HttpGet]
        [Route("getProduct/{IdProduct}")]
        public async Task<IActionResult>  GetProduct(int IdProduct)
        {
             
            return Ok(await _productService.GetById(IdProduct));
        }

    }
}
