using Asentamientos.Models;
using Asentamientos.ModelsViews;
using Asentamientos.ModelsDOCIng;

namespace Asentamientos.Interface
{
    public interface IRotacionData   
    {
        Task<RotaCalidum> GetRotacion(int idEmpresa,int idCentro);     
    }
}