using Asentamientos.Models;
using Asentamientos.DTOs.BPCS;
using Asentamientos.ModelsViews;
using Asentamientos.ModelsDOCIng;

namespace Asentamientos.Interface
{
    public interface IGlobalData   
    {
        Task<RotaCalidum> GetRotacion(int idEmpresa,int idCentro);
        Task<List<OrdenFabricacionDTO>> GetProductosActuales(int idLinea);
    }
}