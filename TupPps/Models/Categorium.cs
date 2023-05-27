﻿using System;
using System.Collections.Generic;

namespace TupPps.Models;

public partial class Categorium
{
    public int IdCategoria { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
