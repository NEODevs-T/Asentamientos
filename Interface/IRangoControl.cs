using Asentamientos.ModelsViews;
using Asentamientos.Models;
using Asentamientos.DTOs;

namespace Asentamientos.Interface
{
    public interface IProductosVData
    {
        Task<List<ProductosV>> GetProductosPorLinea(int idLinea);
    }

    public interface ISeccionesVData
    {
        Task<List<SeccionesV>> GetSeccionesPorLinea(int idLinea);
    }

    public interface IRangoData
    {
        Task<List<Rango>> GetRangoDeControl(FiltrosRangoControlDTO filtros);
    }
}