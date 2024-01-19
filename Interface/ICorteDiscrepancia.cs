using Asentamientos.DTOs;
using Asentamientos.Models;
using Asentamientos.ModelsViews;
using System;

namespace Asentamientos.Interface
{
    public interface ICorteDiscrepancia
    { 
        Task<List<AsentumDTO>> GetAsentamientosFueraRango(string turno, string fecha, int idcentro );
        Task<List<CortesVistaDTO>> GetCortesDiscrepanciaLinea(string turno, string fecha, int idcentro );
        Task<object> AddCorteDiscrepancia(CorteDiscDTO corte);
        Task<List<CategoriaDTO>> GetCategorias();
    }

        
}