using Asentamientos.ModelsViews;
using Asentamientos.Models;
using Asentamientos.DTOs;
using Asentamientos.Interface;

namespace Asentamientos.Data
{
    public class AsentamientoData : IAsentamientoData
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string BaseUrl = "http://neo.paveca.com.ve/apineomaster/api/Asentamientos";
       // private const string BaseUrl = "http://localhost:5021/api/Asentamientos";
        private HttpClient cliente { get; set; } = new HttpClient();

        private HttpResponseMessage? mensaje { get; set; } = new HttpResponseMessage();
        private string url {get; set;} = "";

        public AsentamientoData(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<bool> GetIsAsentamientoHoy(FiltrosRangoControlDTO filtros,int idEmpresa, int idCentro){
            bool band;
            url = $"{BaseUrl}/GetIsAsentamientoHoy/{idEmpresa}/{idCentro}?producto={filtros.producto}&master={filtros.master}&tipo={filtros.tipo}&seccion={filtros.seccion}";
            cliente = _clientFactory.CreateClient();
            band = await cliente.GetFromJsonAsync<bool>(url);
            return band;
        }

        public async Task<bool> AddAsentamientosDelDia(int idEmpresa,int idPais,int idCentro,InfoAse infoAsentamientos, List<Asentum> listaAsentamiento){
            bool band = false;
            InformeConAsentamientosDTO asentamientosData = new InformeConAsentamientosDTO();
            asentamientosData.InformaDeAsentamientosDTO = new InfoAseDTO();
            asentamientosData.AsentamientosDTO = new List<AsentumDTO>();
            
            asentamientosData.InformaDeAsentamientosDTO.Iagrupo = infoAsentamientos.Iagrupo;
            asentamientosData.InformaDeAsentamientosDTO.Iaturno = infoAsentamientos.Iaturno;
            asentamientosData.InformaDeAsentamientosDTO.Iaficha = infoAsentamientos.Iaficha;
            asentamientosData.InformaDeAsentamientosDTO.Iaobser = infoAsentamientos.Iaobser;

            for (int i = 0; i < listaAsentamiento.Count; i++)
            {
                asentamientosData.AsentamientosDTO.Add(new AsentumDTO());
                asentamientosData.AsentamientosDTO[i].Avalor =  listaAsentamiento[i].Avalor;
                asentamientosData.AsentamientosDTO[i].AisActivo = listaAsentamiento[i].AisActivo;
                asentamientosData.AsentamientosDTO[i].IdRango = listaAsentamiento[i].IdRango;
                asentamientosData.AsentamientosDTO[i].Aobserv = listaAsentamiento[i].Aobserv;
            }

            url = $"{BaseUrl}/AddAsentamientosDelDia/{idEmpresa}/{idPais}/{idCentro}";
            cliente =  _clientFactory.CreateClient();
            mensaje = await cliente.PostAsJsonAsync(url,asentamientosData);
            //var error = await mensaje.Content.ReadAsStringAsync();
            if(mensaje.IsSuccessStatusCode){
                band = await mensaje.Content.ReadFromJsonAsync<bool>();
            }
            return band;
        }

        // public async Task<string> UpdateAsentamientosDelDia(long idInforme,InformeConAsentamientosDTO asentamientos){
        //     url = $"{BaseUrl}/UpdateAsentamientosDelDia?idInforme={idInforme}";
        //     cliente =  _clientFactory.CreateClient();
        //     mensaje = await cliente.PutAsJsonAsync(url,asentamientos);
        //     return await mensaje.Content.ReadAsStringAsync();
        // }
    }

    public class ValoresDeAsentamientosVData : IValoresDeAsentamientosVData
    {
        private readonly IHttpClientFactory _clientFactory;
        private HttpClient cliente { get; set; } = new HttpClient();
        private HttpResponseMessage mensaje { get; set; } = new HttpResponseMessage();
        private string url {get; set;} = "";
        private const string BaseUrl = "http://neo.paveca.com.ve/apineomaster/api/Asentamientos";  

        public ValoresDeAsentamientosVData(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }      
        public async Task<List<ValoresDeAsentamientosV>> GetAsentamientosViews(FiltroGTDTO filtro,DateOnly fecha){
            List<ValoresDeAsentamientosV> data;
            string fechaString = fecha.ToString("yyyy-MM-dd");
            url = $"{BaseUrl}/GetAsentamientosViews?grupo={filtro.grupo}&turno={filtro.turno}&Fecha={fechaString}";
            cliente = _clientFactory.CreateClient();
            data = await cliente.GetFromJsonAsync<List<ValoresDeAsentamientosV>>(url) ?? new List<ValoresDeAsentamientosV>();
            return data;
        }
    }
}