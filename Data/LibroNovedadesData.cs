using Asentamientos.DTOs;
using Asentamientos.DTOs.LibroNovedades;
using Asentamientos.Interface;
using Asentamientos.Models;
using Asentamientos.ModelsViews;
using Microsoft.AspNetCore.Routing;
using System.Diagnostics.Eventing.Reader;

namespace Asentamientos.Data
{
    public class LibroNovedadesData : ILibroNovedades
    {

        private readonly IHttpClientFactory _clientFactory;
        //private const string BaseUrl = "http://localhost:5021/api/";
        private const string BaseUrl = "http://neo.paveca.com.ve/apineomaster/api/";

        public LibroNovedadesData(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<bool> AddNovedad(List<LibroNoveDTO> novedades)
        {
            var client = _clientFactory.CreateClient();
            var result = await client.PostAsJsonAsync($"{BaseUrl}LibroNove/AddLibroNovedadesPorCorte", novedades);

            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        //TPM

        public async Task<List<ClasifiTpmDTO>> GetClasificacionTPM()
        {
            var client = _clientFactory.CreateClient();
            var result = await client.GetFromJsonAsync<List<ClasifiTpmDTO>>($"{BaseUrl}TPM/GetClasificacionTPM");
            return result ?? new List<ClasifiTpmDTO>();
        }

        


    }
}

