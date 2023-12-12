using Asentamientos.ModelsViews;
using Asentamientos.Models;
using Asentamientos.DTOs;
using Asentamientos.Interface;

namespace Asentamientos.Data
{
    public class AsentamientoData : IAsentamientoData
    {
        private HttpClient cliente { get; set; } = new HttpClient();
        private HttpResponseMessage mensaje { get; set; } = new HttpResponseMessage();
        private string url {get; set;} = "";
        public async Task<bool> GetIsAsentamientoHoy(FiltrosRangoControlDTO filtros, FiltroGTDTO filtroGT){
            bool band;
            url = $"http://neo.paveca.com.ve/apineomaster/api/Asentamientos/GetIsAsentamientoHoy?producto={filtros.producto}&master={filtros.master}&tipo={filtros.tipo}&seccion={filtros.seccion}&grupo={filtroGT.grupo}&turno={filtroGT.turno}";
            cliente = new HttpClient();
            band = await cliente.GetFromJsonAsync<bool>(url);
            return band;
        }

        public async Task<bool> AddAsentamientosDelDia(InformeConAsentamientosDTO asentamientos){
            bool band;
            url = "http://localhost:5021/api/Asentamientos/AddAsentamientosDelDia";
            cliente = new HttpClient();
            mensaje = await cliente.PostAsJsonAsync(url,asentamientos);
            band = await mensaje.Content.ReadFromJsonAsync<bool>();
            return band;
        }

        public async Task<string> UpdateAsentamientosDelDia(long idInforme,InformeConAsentamientosDTO asentamientos){
            url = $"http://localhost:5021/api/Asentamientos/UpdateAsentamientosDelDia?idInforme={idInforme}";
            cliente = new HttpClient();
            mensaje = await cliente.PutAsJsonAsync(url,asentamientos);
            return await mensaje.Content.ReadAsStringAsync();
        }
    }

    public class ValoresDeAsentamientosVData : IValoresDeAsentamientosVData
    {
        private HttpClient cliente { get; set; } = new HttpClient();
        private HttpResponseMessage mensaje { get; set; } = new HttpResponseMessage();
        private string url {get; set;} = "";
        
        public async Task<List<ValoresDeAsentamientosV>> GetAsentamientosViews(FiltroGTDTO filtro,DateOnly fecha){
            List<ValoresDeAsentamientosV> data;
            string fechaString = fecha.ToString("yyyy-MM-dd");
            url = $"http://localhost:5021/api/Asentamientos/GetAsentamientosViews?grupo={filtro.grupo}&turno={filtro.turno}&Fecha={fechaString}";
            cliente = new HttpClient();
            data = await cliente.GetFromJsonAsync<List<ValoresDeAsentamientosV>>(url) ?? new List<ValoresDeAsentamientosV>();
            return data;
        }
    }
}