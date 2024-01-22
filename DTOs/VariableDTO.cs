namespace Asentamientos.DTOs
{
    public class VariableDTO
    {
        public int IdVariable { get; set; }  
        public int IdUnidad { get; set; } 
        public int IdSeccion { get; set; } 
        public string Vnombre { get; set; } = null!;
        public string? Vdescri { get; set; }
        public bool VisObser { get; set; }
        public virtual UnidadDTO UnidadDTONavigation { get; set; } = null!;
        public virtual SeccionDTO SeccionDTONavigation { get; set; } = null!;
      
    }
}
