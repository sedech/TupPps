using BusnessService.IService;
using BusnessService.Service;
using BussnessEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TupPps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderBe product)
        {
            return Ok(await _orderService.Create(product));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrder([FromQuery] int IdOrder)
        {
            return Ok(await _orderService.Delete(IdOrder));
        }

        [HttpGet]
        [Route("getOrder/{IdOrder}")]
        public async Task<IActionResult> GetOrder(int IdOrder)
        {

            return Ok(await _orderService.GetById(IdOrder));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] OrderBe order)
        {
            return Ok(await _orderService.Update(order));
        }
    }
}
