using Asentamientos.DTOs;
using Asentamientos.Interface;
using Asentamientos.Models;
using Asentamientos.ModelsViews;
using Azure;
using Azure.Identity;

namespace Asentamientos.Data
{
    public class CorteDiscrepaciaData : ICorteDiscrepancia
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string BaseUrl = "http://localhost:5021/api/CorteDiscrepancia/";
        //private const string BaseUrl = "http://neo.paveca.com.ve/apineomaster/api/CorteDiscrepancia/";

        public CorteDiscrepaciaData(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<AsentumDTO>> GetAsentamientosFueraRango(string turno, string fecha, int idlinea)
        {
            
            var client = _clientFactory.CreateClient();
            var result = await client.GetFromJsonAsync<List<AsentumDTO>>($"{BaseUrl}AsentamientoFueraRango/{turno}/{fecha}/{idlinea}");
            return result ?? new List<AsentumDTO>();
        }

        public async Task<List<CortesVistaDTO>> GetCortesDiscrepanciaLinea(string turno, string fecha, int idlinea)
        {
            var client = _clientFactory.CreateClient();
            var result = await client.GetFromJsonAsync<List<CortesVistaDTO>>($"{BaseUrl}CortesDelDiaLineaPorTurno/{turno}/{fecha}/{idlinea}");
            return result ?? new List<CortesVistaDTO>();
        }

        public async Task<object> AddCorteDiscrepancia(CorteDiscDTO corte)
        {
            var client = _clientFactory.CreateClient();
            var result = await client.PostAsJsonAsync($"{BaseUrl}AddCorte",corte);

            if (result.IsSuccessStatusCode)
            {
                
                return true;
            }
            else
            {    
                //TODO:Crear mensaje o log
                var error = await result.Content.ReadAsStringAsync();
                return error;      
                 
            }
        }

        public async Task<List<CategoriaDTO>> GetCategorias()
        {
            var client = _clientFactory.CreateClient();
            var result = await client.GetFromJsonAsync<List<CategoriaDTO>>($"{BaseUrl}CategoriasCorte");
            return result ?? new List<CategoriaDTO>();
        }
    }
}