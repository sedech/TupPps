using TupPps.Models;

namespace TupPps.Entities
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public DateTime Fecha { get; set; }
        public Cliente Cliente { get; set; }
        public Vendedor Vendedor { get; set; }
        public List<PedidoItem> Items { get; set; }

        public Pedido(int idPedio, DateTime fecha, Cliente cliente, Vendedor vendedor)
        {
            IdPedido = idPedio;
            Fecha = fecha;
            Cliente = cliente;
            Vendedor = vendedor;
            Items = new List<PedidoItem>();
        }

        // agregar un nuevo item al pedido 
        public void AgregarItem(PedidoItem item)
        {
            Items.Add(item);
        }

        public float CalcularTotal()
        {
            float total = 0;
            foreach (PedidoItem item in Items)
            {
                total += item.CalcularSubtotal();
            }
            return total;
        }
    }
}
