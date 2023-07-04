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

        /*
         permite crear un nuevo pedido. Recibe un objeto OrderBe en el cuerpo de la solicitud que contiene los datos del pedido. 
        Llama al método Create del servicio de pedidos (IOrderService) pasando este objeto y 
        devuelve una respuesta exitosa (200 OK) con el resultado de la creación del pedido.
         */

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderBe product)
        {
            return Ok(await _orderService.Create(product));
        }


        /*
         permite eliminar un pedido existente. Recibe un parámetro IdOrder desde la consulta.
        Llama al método Delete del servicio de pedidos pasando este ID de pedido y 
        devuelve una respuesta exitosa (200 OK) con el resultado de la eliminación del pedido.
         */
        [HttpDelete]
        public async Task<IActionResult> DeleteOrder([FromQuery] int IdOrder)
        {
            return Ok(await _orderService.Delete(IdOrder));
        }


        /*
         permite obtener un pedido específico por su ID. Toma un parámetro IdOrder en la URL. 
        Llama al método GetById del servicio de pedidos pasando este ID y 
        devuelve una respuesta exitosa (200 OK) con los detalles del pedido obtenido.
         */
        [HttpGet]
        [Route("getOrder/{IdOrder}")]
        public async Task<IActionResult> GetOrder(int IdOrder)
        {

            return Ok(await _orderService.GetById(IdOrder));
        }

        /*
          permite actualizar un pedido existente. Recibe un objeto OrderBe en el cuerpo de la solicitud 
        que contiene los nuevos datos del pedido. Llama al método Update del servicio 
        de pedidos pasando este objeto y devuelve una respuesta exitosa (200 OK) con el resultado de la actualización del pedido.
         */

        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] OrderBe order)
        {
            return Ok(await _orderService.Update(order));
        }
    }
}
