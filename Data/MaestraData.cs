using Asentamientos.Interface;
using Asentamientos.Models;
using Asentamientos.ModelsViews;


namespace Asentamientos.Data
{
    public class MaestraData : IMaestra
    {
        private readonly HttpClient _http;
        public MaestraData(HttpClient http)
        {
            _http = http;

        }
        public async Task<List<Pai>> GetPaises()
        {
            //var result = await _http.GetFromJsonAsync<List<Pai>>($"http://neo.paveca.com.ve/apineomaster/api/Maestra/GetPaises");          
            //return result;
            string baseUrl = "http://neo.paveca.com.ve/apineomaster/api/Maestra/GetPaises";
            List<Pai> result = null;

            try
            {
                result = await _http.GetFromJsonAsync<List<Pai>>(baseUrl);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return result ?? new List<Pai>();
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

      
    }
}
