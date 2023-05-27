using System;
using System.Collections.Generic;

namespace TupPps.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Cuit { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public string? Email { get; set; }

    public string? RazonSocial { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
