using System;
using System.Collections.Generic;

namespace TupPps.Models;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public DateTime? Fecha { get; set; }

    public int? IdCliente { get; set; }

    public int? IdVendedor { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Vendedor? IdVendedorNavigation { get; set; }
}
