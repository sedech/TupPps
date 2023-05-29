using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TupPps.Entities;

namespace TupPps.Models.Request
{
    public class ProductoRequest
    {
        public int IdProducto { get; set; }
        public string? Descripcion { get; set; }
        public int CantidadStock { get; set; }
        public float Precio { get; set; }
        public Proveedor? Proveedor { get; set; }
        public Categoria? Categoria { get; set; }
    }
}
