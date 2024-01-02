using Asentamientos.ModelsViews;
using Asentamientos.Models;
using Asentamientos.DTOs;
using Asentamientos.Interface;

namespace Asentamientos.Data
{
    public class ProductosVData : IProductosVData
    {
        private readonly IHttpClientFactory _clientFactory;
        private HttpClient cliente { get; set; } = new HttpClient();
        private HttpResponseMessage mensaje { get; set; } = new HttpResponseMessage();
        private string url {get; set;} = "";
        private const string BaseUrl = "http://neo.paveca.com.ve/apineomaster/api/RangoControl";
        public ProductosVData(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<List<ProductosV>> GetProductosPorLinea(int idLinea){
            List<ProductosV> productos;
            url = $"{BaseUrl}/GetProductosPorLinea/{idLinea}";
            cliente = _clientFactory.CreateClient();
            productos = await cliente.GetFromJsonAsync<List<ProductosV>>(url) ?? new List<ProductosV>();
            return productos;
        }
    }
    public class SeccionesVData : ISeccionesVData
    {
        private readonly IHttpClientFactory _clientFactory;
        private HttpClient cliente { get; set; } = new HttpClient();
        private HttpResponseMessage mensaje { get; set; } = new HttpResponseMessage();
        private string url {get; set;} = "";
        private const string BaseUrl = "http://neo.paveca.com.ve/apineomaster/api/RangoControl";
        public SeccionesVData(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<List<SeccionesV>> GetSeccionesPorLinea(int idLinea){
            List<SeccionesV> secciones;
            url = $"{BaseUrl}/GetSeccionesPorLinea/{idLinea}";
            cliente = _clientFactory.CreateClient();
            secciones = await cliente.GetFromJsonAsync<List<SeccionesV>>(url) ?? new List<SeccionesV>();
            return secciones;
        }

    }

    public class RangoData : IRangoData{
        private HttpClient cliente { get; set; } = new HttpClient();
        private readonly IHttpClientFactory _clientFactory;
        private HttpResponseMessage mensaje { get; set; } = new HttpResponseMessage();
        private string url {get; set;} = "";
        private const string BaseUrl = "http://neo.paveca.com.ve/apineomaster/api/RangoControl";
        public RangoData(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<List<Rango>> GetRangoDeControl(FiltrosRangoControlDTO filtros)
        {
            List<Rango> rangos;
            url = $"{BaseUrl}/GetRangoDeControl?producto={filtros.producto}&master={filtros.master}&tipo={filtros.tipo}&seccion={filtros.seccion}";
            cliente = _clientFactory.CreateClient();
            rangos = await cliente.GetFromJsonAsync<List<Rango>>(url) ?? new List<Rango>();
            return rangos;
        }
    }

    public class VariableData : IVaribleData {
        private readonly IHttpClientFactory _clientFactory;
        private HttpClient cliente { get; set; } = new HttpClient();
        private HttpResponseMessage mensaje { get; set; } = new HttpResponseMessage();
        private string url {get; set;} = "";
        private const string BaseUrl = "http://neo.paveca.com.ve/apineomaster/api/RangoControl";
        public VariableData(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        
        public async Task<List<VarClasificacionV>> GetClasificacionVarPorLinea(int idLinea)
        {
            List<VarClasificacionV> clasificaciones;
            url = $"{BaseUrl}/GetClasificacionVariblePorLinea/{idLinea}";
            cliente = _clientFactory.CreateClient();
            clasificaciones = await cliente.GetFromJsonAsync<List<VarClasificacionV>>(url) ?? new List<VarClasificacionV>();
            return clasificaciones;
        }

        public async Task<List<VarTipoV>> GetTipoVarPorLinea(int idLinea)
        {
            List<VarTipoV> tipos;
            url = $"{BaseUrl}/GetTipoVariblePorLinea/{idLinea}";
            cliente = _clientFactory.CreateClient();
            tipos = await cliente.GetFromJsonAsync<List<VarTipoV>>(url) ?? new List<VarTipoV>();
            return tipos;
        }
    }

}