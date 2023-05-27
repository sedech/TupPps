using System;
using System.Collections.Generic;

namespace TupPps.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Descripcion { get; set; }

    public int? CantidadStock { get; set; }

    public double? Precio { get; set; }

    public int? IdProveedor { get; set; }

    public int? IdCategoria { get; set; }

    public virtual Categorium? IdCategoriaNavigation { get; set; }

    public virtual Proveedor? IdProveedorNavigation { get; set; }

    public virtual ICollection<PedidoItem> PedidoItems { get; set; } = new List<PedidoItem>();
}
