using Asentamientos.Interface;
using Asentamientos.Models;
using Asentamientos.ModelsViews;
using Asentamientos.ModelsDOCIng;

namespace Asentamientos.Data
{
    public class RotacionData : IRotacionData
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string BaseUrl = "http://neo.paveca.com.ve/apineomaster/api/Global/";
        private string url = "";
        public RotacionData( IHttpClientFactory clientFactory)
        {
            
            _clientFactory = clientFactory;
        }
        public async Task<RotaCalidum> GetRotacion(int IdPais){
            try
            {
                var client = _clientFactory.CreateClient();
                var result = await client.GetFromJsonAsync<RotaCalidum>($"{BaseUrl}GetRotacion/{IdPais}");
                return result ?? new RotaCalidum();
            }
            catch
            {
                return new RotaCalidum();
            }
        }
    }
}