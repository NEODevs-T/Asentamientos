using Asentamientos.DTOs;
using Asentamientos.Models;
using Asentamientos.ModelsViews;
using System;

namespace Asentamientos.Interface
{ 
    public interface ICorteDiscrepancia
    { 
        Task<List<AsentumDTO>> GetAsentamientosFueraRangoFiltros(string turno, string fecha, int idlinea, int idClasiVar, int idSeccion, int idProducto);
        Task<List<AsentumDTO>> GetAsentamientosFueraRango(string turno, string fecha, int idlinea);
        Task<List<CortesVistaDTO>> GetCortesDiscrepanciaLinea(string turno, string fecha, int idcentro);
        Task<List<CortesVistaDTO>> GetCortesDiscrepanciaLineaFiltrado(string turno, string fecha, int idcentro,int idClasiVar, int idSeccion, int idProducto);
        Task<bool> UpdateAentamientosCortes(List<AsentumDTO> cortes);
        Task<bool> UpdateCorte(CorteDiscDTO corte);
        Task<object> AddCorteDiscrepancia(CorteDiscDTO corte);
        Task<List<CategoriaDTO>> GetCategorias();
    }     
}