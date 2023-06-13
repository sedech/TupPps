using BusnessService.IService;
using BussnessEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TupPps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerBe customer)
        {
            return Ok(await _customerService.Create(customer));
        }

        [HttpGet]
        [Route("getCustomer/{IdCustomer}")]
        public async Task<IActionResult> GetProduct(int IdCustomer)
        {

            return Ok(await _customerService.GetById(IdCustomer));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerBe customer)
        {
            return Ok(await _customerService.Update(customer));
        }
    }
}
