using Asentamientos.ModelsViews;
using Asentamientos.Models;
using Asentamientos.DTOs;
using Asentamientos.Interface;

namespace Asentamientos.Data
{
    public class ProductosVData : IProductosVData
    {
        private HttpClient cliente { get; set; }
        private HttpResponseMessage mensaje { get; set; }

        private string url {get; set;}
        public async Task<List<ProductosV>> GetProductosPorLinea(int idLinea){
            List<ProductosV> productos;
            url = "http://neo.paveca.com.ve/apineomaster/api/RangoControl/GetProductosPorLinea";
            cliente = new HttpClient();
            mensaje = await cliente.PostAsJsonAsync(url,idLinea);
            productos = await mensaje.Content.ReadFromJsonAsync<List<ProductosV>>() ?? new List<ProductosV>();
            return productos;
        }
    }
}