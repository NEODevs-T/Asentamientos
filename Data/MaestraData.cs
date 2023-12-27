using Asentamientos.Interface;
using Asentamientos.Models;
using Asentamientos.ModelsViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;


namespace Asentamientos.Data
{
    public class MaestraData : IMaestra
    {
        private readonly HttpClient _http;
        private readonly IHttpClientFactory _clientFactory;
        private const string BaseUrl = "http://neo.paveca.com.ve/apineomaster/api/Maestra/";
        private string url = "";

        public MaestraData(HttpClient http, IHttpClientFactory clientFactory)
        {
            _http = http;
            _clientFactory = clientFactory;
        }
        public async Task<List<Pai>> GetPaises()
        {
            try
            {
                var client = _clientFactory.CreateClient();
                var result = await client.GetFromJsonAsync<List<Pai>>($"{BaseUrl}GetPaises");             
                return result ?? new List<Pai>();
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                throw;
            }
        }
        public async Task<List<EmpresasV>> GetEmpresas(int IdPais)
        {
            var result = await _http.GetFromJsonAsync<List<EmpresasV>>($"http://neo.paveca.com.ve/apineomaster/api/Maestra/GetEmpresas/{IdPais}");
            return result;
        }

        public async Task<List<CentrosV>> GetCentros(int IdEmpresa)
        {
            var result = await _http.GetFromJsonAsync<List<CentrosV>>($"http://neo.paveca.com.ve/apineomaster/api/Maestra/GetCentros/{IdEmpresa}");
            return result;
        }

        public async Task<List<DivisionesV>> GetDivisiones(int IdCentro)
        {
            var result = await _http.GetFromJsonAsync<List<DivisionesV>>($"http://neo.paveca.com.ve/apineomaster/api/Maestra/GetDivisiones/{IdCentro}");
            return result;
        }
      
        public async Task<List<LineaV>> GetLineas(int IdDivision)
        {
            var result = await _http.GetFromJsonAsync<List<LineaV>>($"http://neo.paveca.com.ve/apineomaster/api/Maestra/GetLineas/{IdDivision}");
            return result;
        }

        public async Task<int> GetMaestraPorLinea(int idLinea){
            url = $"http://neo.paveca.com.ve/apineomaster/api/maestra/GetMaestraPorLinea/{idLinea}";
            return await _http.GetFromJsonAsync<int>(url);
        }
    }
}
