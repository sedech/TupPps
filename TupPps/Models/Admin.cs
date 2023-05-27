using System;
using System.Collections.Generic;

namespace TupPps.Models;

public partial class Admin
{
    public int IdAdmin { get; set; }

    public string? Nombre { get; set; }

    public string? Password { get; set; }
}
