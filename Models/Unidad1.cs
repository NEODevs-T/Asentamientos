using System;
using System.Collections.Generic;

namespace Asentamientos.Models;

public partial class Unidad1
{
    public int IdUnidad { get; set; }

    public string Unombre { get; set; } = null!;

    public string? Udescri { get; set; }

    public bool Uestado { get; set; }
}
