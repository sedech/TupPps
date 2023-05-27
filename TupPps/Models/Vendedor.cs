using System;
using System.Collections.Generic;

namespace TupPps.Models;

public partial class Vendedor
{
    public int IdVendedor { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public string Email { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
