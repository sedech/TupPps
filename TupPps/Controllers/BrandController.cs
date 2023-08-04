using BusnessService.IService;
using BusnessService.Service;
using BussnessEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TupPps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            this._brandService = brandService;
        }

       
        /*
          permite crear una nueva marca. Recibe un objeto BrandToCreateBe en el cuerpo de la solicitud. 
        Llama al método Create del servicio de marcas pasando este objeto 
        y devuelve una respuesta exitosa (200 OK) con el resultado de la creación de la marca.
         */

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Vendedor")]
        [HttpPost]
        public async Task<IActionResult> CreateBrand([FromBody] BrandToCreateBe brand)
        {
            return Ok(await _brandService.Create(brand));
        }


        /*
         permite obtener una marca específica por su ID. Toma un parámetro IdBrand en la URL. 
        Llama al método GetById del servicio de marcas pasando este ID 
        y devuelve una respuesta exitosa (200 OK) con los detalles de la marca obtenida.
         */

        //[Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Vendedor")]
        [HttpGet]
        [Route("getBrand/{IdBrand}")]
        public async Task<IActionResult> GetBrand(int IdBrand)
        {

            return Ok(await _brandService.GetById(IdBrand));
        }


        /*
          permite actualizar una marca existente. Recibe un objeto BrandBe en el cuerpo de la solicitud 
        que contiene los nuevos datos de la marca. Llama al método Update del servicio de marcas pasando 
        este objeto y devuelve una respuesta exitosa (200 OK) con el resultado de la actualización de la marca.
         */

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Vendedor")]
        [HttpPut]
        public async Task<IActionResult> UpdateBrand([FromBody] BrandBe brand)
        {
            return Ok(await _brandService.Update(brand));
        }

        [HttpGet]
        [Route("AllBrands")]
        public async Task<ActionResult<IEnumerable<BrandBe>>> GetAllBrands()
        {
            var brands = await _brandService.GetAll();

            return Ok(brands);
        }


    }
}
