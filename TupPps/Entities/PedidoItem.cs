using TupPps.Models;

namespace TupPps.Entities
{
    /*
    la entidad "PedidoItem" es una entidad que representa un producto específico en un pedido,
   y se utiliza para almacenar información específica de ese producto dentro del contexto de un pedido.
    "PedidoItem" va a estar relacionada con otras entidades de la base de datos, 
   como la entidad "Pedido" y la entidad "Producto
    */

    public class PedidoItem
    {
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }

        public PedidoItem(Producto producto, int cantidad)
        {
            Producto = producto;
            Cantidad = cantidad;
        }

        // calcular el subtotal del item 

        public float CalcularSubtotal()
        {
            return Producto.Precio * Cantidad;
        }
    }
}
