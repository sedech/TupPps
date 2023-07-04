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

        /*
         permite crear un nuevo elemento de pedido. Recibe un objeto OrderItemBe en el cuerpo de la solicitud 
        que contiene los datos del elemento de pedido. Llama al método Create del servicio 
        de elementos de pedido (IOrderItemService) pasando este objeto y devuelve una respuesta exitosa (200 OK) con el resultado de la creación del elemento de pedido.
         */

        [HttpPost]
        public async Task<IActionResult> CreateOrderItem([FromBody] OrderItemBe product)
        {
            return Ok(await _orderItemService.Create(product));
        }


        /*
         ermite eliminar un elemento de pedido existente. Recibe un parámetro IdOrderItem desde la consulta. Llama al método Delete del servicio 
        de elementos de pedido pasando este ID del elemento de pedido y 
        devuelve una respuesta exitosa (200 OK) con el resultado de la eliminación del elemento de pedido.
         */
        [HttpDelete]
        public async Task<IActionResult> DeleteOrderItem([FromQuery] int IdOrderItem)
        {
            return Ok(await _orderItemService.Delete(IdOrderItem));
        }


        /*
          permite obtener un elemento de pedido específico por su ID. Toma un parámetro IdOrderItem en la URL.
        Llama al método GetById del servicio de elementos de pedido pasando este ID y 
        devuelve una respuesta exitosa (200 OK) con los detalles del elemento de pedido obtenido.
         */
        [HttpGet]
        [Route("getOrderItem/{IdOrderItem}")]
        public async Task<IActionResult> GetOrderItem(int IdOrderItem)
        {

            return Ok(await _orderItemService.GetById(IdOrderItem));
        }

        /*
         permite actualizar un elemento de pedido existente. 
        Recibe un objeto OrderItemBe en el cuerpo de la solicitud que contiene 
        los nuevos datos del elemento de pedido. Llama al método Update del servicio 
        de elementos de pedido pasando este objeto y devuelve una respuesta exitosa (200 OK) con el resultado de la actualización del elemento de pedido.
         */

        [HttpPut]
        public async Task<IActionResult> UpdateOrderItem([FromBody] OrderItemBe orderItem)
        {
            return Ok(await _orderItemService.Update(orderItem));
        }

    }
}
