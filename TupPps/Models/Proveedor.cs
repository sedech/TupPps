using System;
using System.Collections.Generic;

namespace TupPps.Models;

public partial class Proveedor
{
    public int IdProveedor { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Direccion { get; set; }

    public string? Email { get; set; }

    public string? SitioWeb { get; set; }

    public string? RazonSocial { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
