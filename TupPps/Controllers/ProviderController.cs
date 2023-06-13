using BusnessService.IService;
using BussnessEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TupPps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderService _providerService;

        public ProviderController(IProviderService providerService)
        {
            this._providerService = providerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProviderr([FromBody] ProviderBe provider)
        {
            return Ok(await _providerService.Create(provider));
        }

        [HttpGet]
        [Route("getProvider/{IdProvider}")]
        public async Task<IActionResult> GetProvider(int IdProvider)
        {

            return Ok(await _providerService.GetById(IdProvider));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProvider([FromBody] ProviderBe provider)
        {
            return Ok(await _providerService.Update(provider));
        }
    }
}
