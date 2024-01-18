using System;
using System.Collections.Generic;

namespace Asentamientos.ModelsDOCIng;

public partial class RotaCalidum
{
    public int RcidRotCal { get; set; }

    public int Rcfecha { get; set; }

    public int Rcturno { get; set; }

    public string Rcgrupo { get; set; } = null!;
}
