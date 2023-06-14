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
    public class OrderItemController : ControllerBase
    {   
        private readonly IOrderItemService _orderItemService;
        public OrderItemController(IOrderItemService orderItemService)
        {
            this._orderItemService = orderItemService;
        }

      
        [HttpPost]
        public async Task<IActionResult> CreateOrderItem([FromBody] OrderItemBe product)
        {
            return Ok(await _orderItemService.Create(product));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrderItem([FromQuery] int IdOrderItem)
        {
            return Ok(await _orderItemService.Delete(IdOrderItem));
        }

        [HttpGet]
        [Route("getOrderItem/{IdOrderItem}")]
        public async Task<IActionResult> GetOrderItem(int IdOrderItem)
        {

            return Ok(await _orderItemService.GetById(IdOrderItem));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderItem([FromBody] OrderItemBe orderItem)
        {
            return Ok(await _orderItemService.Update(orderItem));
        }

    }
}
