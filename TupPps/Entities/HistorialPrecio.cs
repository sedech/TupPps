using TupPps.Models;

namespace TupPps.Entities
{
    public class HistorialPrecio
    {
        public Producto Producto { get; set; }
        public float Precio { get; set; }
        public DateTime Fecha { get; set; }

        public HistorialPrecio(Producto producto, float precio, DateTime fecha)
        {
            Producto = producto;
            Precio = precio;
            Fecha = fecha;
        }

        public string ObtenerInformacion()
        {
            string informacion = $"Producto: {Producto.Descripcion}\n";
            informacion += $"Precio: {Precio}\n";
            informacion += $"Fecha: {Fecha}\n";
            return informacion;
        }
    }
}
