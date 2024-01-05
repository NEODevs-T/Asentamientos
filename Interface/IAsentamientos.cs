using Asentamientos.ModelsViews;
using Asentamientos.Models;
using Asentamientos.DTOs;

namespace Asentamientos.Interface
{
    public interface IAsentamientoData{
        Task<bool> GetIsAsentamientoHoy(FiltrosRangoControlDTO filtros, FiltroGTDTO filtroGT);
        Task<bool> AddAsentamientosDelDia(InfoAse infoAsentamientos, List<Asentum> listaAsentamiento);
        // Task<string> UpdateAsentamientosDelDia(long idInforme,InformeConAsentamientosDTO asentamientos);
    }

    public interface IValoresDeAsentamientosVData{
        Task<List<ValoresDeAsentamientosV>> GetAsentamientosViews(FiltroGTDTO filtro,DateOnly fecha);
    }
}
