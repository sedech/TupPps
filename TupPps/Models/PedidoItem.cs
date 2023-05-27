using System;
using System.Collections.Generic;

namespace TupPps.Models;

public partial class PedidoItem
{
    public int IdPedidoitem { get; set; }

    public int? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
