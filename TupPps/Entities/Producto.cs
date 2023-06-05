using TupPps.Models;

namespace TupPps.Entities
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public int CantidadStock { get; set; }
        public float Precio { get; set; }
        public int IdProveedor { get; set; }

        public int IdCategoria { get; set; }
        // proveedor imagen

        public Producto(int idProducto, string descripcion, int cantidadStock, float precio, Proveedor proveedor, Categoria categoria)
        {
            IdProducto = idProducto;
            Descripcion = descripcion;
            CantidadStock = cantidadStock;
            Precio = precio;
            Proveedor = proveedor;
            Categoria = categoria;
        }

        public Producto()
        {
        }

        // Actualizar la cantidad de stock del producto
        public void ActualizarStock(int nuevaCantidad)
        {
            CantidadStock = nuevaCantidad;
        }

        public float CalcularValor()
        {
            return CantidadStock * Precio;
        }

        public string ObtenerInformacion()
        {
            string informacion = $"Id Producto: {IdProducto}\n";
            informacion += $"Descripcion: {Descripcion}\n";
            informacion += $"Cantidad Stock: {CantidadStock}\n";
            informacion += $"Precio: {Precio}\n";
            informacion += $"Proveedor: {Proveedor}\n";
            informacion += $"Categoria: {Categoria}\n";
            return informacion;
        }

        public static Producto AgregarProducto(int idProducto, string descripcion, int cantidadStock, float precio, Proveedor proveedor, Categoria categoria)
        {
            Producto nuevoProdcuto = new Producto(idProducto, descripcion, cantidadStock, precio, proveedor, categoria);
            return nuevoProdcuto;
        }

    }
}
