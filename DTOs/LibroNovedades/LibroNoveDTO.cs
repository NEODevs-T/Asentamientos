using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Asentamientos.DTOs.LibroNovedades;

public class LibroNoveDTO
{
    public int IdlibrNov { get; set; }

    public int IdLinea { get; set; }

    [Required(ErrorMessage = "El campo Codigo de Equipo es requerido")]
    public string IdEquipo { get; set; } = null!;

    [Required(ErrorMessage = "El campo Discrepancia es requerido")]
    [StringLength(150, ErrorMessage = "El campo Discrepancia no debe tener más de {1} carácteres")]
    public string Lndiscrepa { get; set; } = null!; 

    public double LntiePerMi { get; set; }

    public string LnfichaRes { get; set; } = null!;

    public DateTime Lnfecha { get; set; }

    public string Lngrupo { get; set; } = null!;

    public string Lnturno { get; set; } = null!;

    public string IdMaquina { get; set; } = null!;

    public int IdTipoNove { get; set; }

    public int IdAreaCar { get; set; }

    [StringLength(500, ErrorMessage = "El campo Observación no debe tener más de {1} carácteres")]
    public string? Lnobserv { get; set; }

    public string? IdParada { get; set; } 

    public bool LnisPizUni { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "El campo Categoría no es correcto.")]
    public int IdCtpm { get; set; } 

    public int? LnisResu { get; set; }
}