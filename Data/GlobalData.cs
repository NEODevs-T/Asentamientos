using Asentamientos.Interface;
using Asentamientos.Models;
using Asentamientos.ModelsViews;
using Asentamientos.ModelsDOCIng;
using Asentamientos.DTOs.BPCS;

namespace Asentamientos.Data
{
    public class GlobalData : IGlobalData
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string BaseUrl = "http://neo.paveca.com.ve/apineomaster/api/Global/";
        private string url = "";
        public GlobalData( IHttpClientFactory clientFactory)
        {
            
            _clientFactory = clientFactory;
        }
        public async Task<RotaCalidum> GetRotacion(int idEmpresa,int idCentro){
            try
            {
                var client = _clientFactory.CreateClient();
                var result = await client.GetFromJsonAsync<RotaCalidum>($"{BaseUrl}GetRotacion/{idEmpresa}/{idCentro}");
                return result ?? new RotaCalidum();
            }
            catch
            {
                return new RotaCalidum();
            }
        }

        public async Task<List<OrdenFabricacionDTO>> GetProductosActuales(int idLinea){
            try
            {

                List<OrdenFabricacionDTO> ordenFabricacionDTOsList;
                url = $"{BaseUrl}GetProductosActuales/{idLinea}";
                var cliente = _clientFactory.CreateClient();
                ordenFabricacionDTOsList = await cliente.GetFromJsonAsync<List<OrdenFabricacionDTO>>(url) ?? new List<OrdenFabricacionDTO>();
                return ordenFabricacionDTOsList;
            }
            catch(Exception e)
            {
                return new List<OrdenFabricacionDTO>();
            }
        }
    }
}