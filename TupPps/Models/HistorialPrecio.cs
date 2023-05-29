using System;
using System.Collections.Generic;

namespace TupPps.Models;

public partial class HistorialPrecio
{
    public int? IdProducto { get; set; }

    public double? Precio { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
