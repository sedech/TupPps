using BusnessService.IService;
using BussnessEntities;
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

        [HttpGet]
        public async Task<IActionResult> GetAllBrandAsync(int state = 1, string name = "")
        {
            List<BrandBe> brand = await this._brandService.GetAll(state, name);
            return Ok(brand);
        }


        [HttpPost]
        public async Task<IActionResult> CreateBrand([FromBody] BrandToCreateBe brand)
        {
            return Ok(await _brandService.Create(brand));
        }

        [HttpGet]
        [Route("getBrand/{IdBrand}")]
        public async Task<IActionResult> GetBrand(int IdBrand)
        {

            return Ok(await _brandService.GetById(IdBrand));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBrand([FromBody] BrandBe brand)
        {
            return Ok(await _brandService.Update(brand));
        }
    }
}
