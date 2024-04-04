namespace Asentamientos.DTOs
{
    public class ProductosDTO
    {
        public int IdProducto { get; set; }

        public int IdTipoProd { get; set; }

        public string Pnombre { get; set; } = null!;

        public string? Pdescri { get; set; }
        public string Pcodigo { get; set; } = null!;
        public virtual ICollection<RangoDTO> RangosDTO { get; set; } = new List<RangoDTO>();

    }

    

}
