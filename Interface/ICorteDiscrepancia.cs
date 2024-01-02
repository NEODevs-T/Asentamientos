using Asentamientos.Models;
using Asentamientos.ModelsViews;

namespace Asentamientos.Interface
{
    public interface ICorteDiscrepancia
    { 
        Task<List<Asentum>> GetAsentamientosFueraRango(string turno, string fecha, int idcentro );
    }
        
}