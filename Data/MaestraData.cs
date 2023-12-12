using Asentamientos.Interface;
using Asentamientos.Models;
using static System.Net.WebRequestMethods;

namespace Asentamientos.Data
{
    public class MaestraData : IMaestra
    {
        public Task GetEmpresa()
        {
            //var result = await _http.GetFromJsonAsync<List<EquipoEam>>($"http://neo.paveca.com.ve/ReunionApi/Lineas/Equipos/{cent}");
            ////var result = await _http.GetFromJsonAsync<List<EquipoEam>>($"http://localhost:5258/Lineas/Equipos/{cent}");
            //if (result != null)
            //    equipos = result;
            throw new NotImplementedException();
        }

        public Task GetPaises()
        {
            throw new NotImplementedException();
        }
    }
}
