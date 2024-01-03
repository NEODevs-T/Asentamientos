using Asentamientos.DTOs;
using Asentamientos.Models;
using Asentamientos.ModelsViews;
using System;

namespace Asentamientos.Interface
{
    public interface ICorteDiscrepancia
    { 
        Task<List<Asentum>> GetAsentamientosFueraRango(string turno, string fecha, int idcentro );
        Task<List<CorteDiscDTO>> GetCortesDiscrepancia(string turno, string fecha, int idcentro );
        Task<object> AddCortesDiscrepancias(List<CorteDiscDTO>? cortes);
        Task<List<CategoriaDTO>> GetCategorias();
    }

        
}