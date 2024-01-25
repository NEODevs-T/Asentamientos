using Asentamientos.DTOs;
using Asentamientos.DTOs.LibroNovedades;

namespace Asentamientos.Interface
{
    public interface ILibroNovedades
    {
        Task<bool> AddNovedad(List<LibroNoveDTO> novedades);
        Task<List<ClasifiTpmDTO>> GetClasificacionTPM();

    }
}
