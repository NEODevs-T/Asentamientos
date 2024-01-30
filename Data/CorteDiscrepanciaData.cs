using Asentamientos.DTOs;
using Asentamientos.Interface;
using Asentamientos.Models;
using Asentamientos.ModelsViews;
using Azure;
using Azure.Identity;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml;
using Asentamientos.Components;

namespace Asentamientos.Data
{
    public class CorteDiscrepaciaData : ICorteDiscrepancia
    {
        private readonly IHttpClientFactory _clientFactory;
       //private const string BaseUrl = "http://localhost:5021/api/CorteDiscrepancia/";
        private const string BaseUrl = "http://neo.paveca.com.ve/apineomaster/api/CorteDiscrepancia/";
        
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
        public async Task<List<AsentumDTO>> GetAsentamientosFueraRangoFiltros(string turno, string fecha, int idlinea, int idClasiVar, int idSeccion, int idProducto)
        {
            
            var client = _clientFactory.CreateClient();
            var result = await client.GetFromJsonAsync<List<AsentumDTO>>($"{BaseUrl}AsentamientoFueraRangoFiltros/{turno}/{fecha}/{idlinea}/{idClasiVar}/{idSeccion}/{idProducto}");
            return result ?? new List<AsentumDTO>();
        }
        //Default operadores?
        public async Task<List<CortesVistaDTO>> GetCortesDiscrepanciaLineaFiltrado(string turno, string fecha, int idlinea, int idClasiVar, int idSeccion, int idProducto)
        {
            var client = _clientFactory.CreateClient();
            var result = await client.GetFromJsonAsync<List<CortesVistaDTO>>($"{BaseUrl}CortesDelDiaLineaFiltros/{turno}/{fecha}/{idlinea}/{idClasiVar}/{idSeccion}/{idProducto}");
            return result ?? new List<CortesVistaDTO>();
           
        }
        public async Task<List<CortesVistaDTO>> GetCortesDiscrepanciaLinea(string turno, string fecha, int idlinea)
        {
            var client = _clientFactory.CreateClient();
            var result = await client.GetFromJsonAsync<List<CortesVistaDTO>>($"{BaseUrl}CortesDelDiaLinea/{turno}/{fecha}/{idlinea}");
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

        public async Task<bool> UpdateAentamientosCortes(List<AsentumDTO> cortes)
        {          
            try
            {
              
                var client = _clientFactory.CreateClient();
                var result = await client.PutAsJsonAsync($"{BaseUrl}UpdateCorteAsentamientoLista", cortes);
                return result.IsSuccessStatusCode;

            }
            catch 
            {
                return false;
            }
        }

        public async Task<bool> UpdateCorte(CorteDiscDTO corte)
        {
            try
            {
                var client = _clientFactory.CreateClient();
                var result = await client.PutAsJsonAsync($"{BaseUrl}UpdateCorte", corte);
                return result.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}