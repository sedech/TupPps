using System;
using System.Collections.Generic;

namespace TupPps.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Mail { get; set; }

    public string? Password { get; set; }

    public string? Tipo { get; set; }
}
