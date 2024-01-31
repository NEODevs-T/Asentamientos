using System.ComponentModel.DataAnnotations;

namespace Asentamientos.DTOs
{
    public class DialogCorteDTO
    {
        [Range(1, int.MaxValue, ErrorMessage = "El campo Categoría no es correcto.")]
        public int IdCategori { get; set; } 

        [Required(ErrorMessage = "El campo Acción Correctiva es requerido")]
        [StringLength(500, ErrorMessage = "El campo Acción no debe tener mas de {1} carácteres")]
        public string CdaccCorr { get; set; } = null!;

        public bool CdisListo { get; set; } = false;

        public double Avalor { get; set; }

        [StringLength(300, ErrorMessage = "El campo Observación no debe tener mas de {1} carácteres")]
        public string? Aobserv { get; set; }
    }
}
