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
        private const string BaseUrl = "http://neo.paveca.com.ve/apineomaster/api/CorteDiscrepancia/";

        public CorteDiscrepaciaData(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<Asentum>> GetAsentamientosFueraRango(string turno, string fecha, int idcentro)
        {
            
            var client = _clientFactory.CreateClient();
            var result = await client.GetFromJsonAsync<List<Asentum>>($"{BaseUrl}AsentamientoFueraRango/{turno}/{fecha}/{idcentro}");
            return result ?? new List<Asentum>();
        }

        public Task<List<CorteDiscDTO>> GetCortesDiscrepancia(string turno, string fecha, int idcentro)
        {
            throw new NotImplementedException();
        }

        public async Task<object> AddCortesDiscrepancias(List<CorteDiscDTO>? cortes)
        {
            var client = _clientFactory.CreateClient();
            var result = await client.PutAsJsonAsync($"{BaseUrl}AddCorte",cortes);

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