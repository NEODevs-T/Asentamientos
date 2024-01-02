using Asentamientos.Interface;
using Asentamientos.Models;
using Asentamientos.ModelsViews;

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
    }
}