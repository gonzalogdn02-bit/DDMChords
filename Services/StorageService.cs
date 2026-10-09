using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using DDMChords.Models;

namespace DDMChords.Services
{
    public class StorageService
    {
        private readonly HttpClient _http;
        private readonly IJSRuntime _jsRuntime; // Lo dejamos para no romper inyección de dependencias
        private const string FirebaseUrl = "https://ddmchords-default-rtdb.firebaseio.com/";

        public StorageService(IJSRuntime jsRuntime, HttpClient http)
        {
            _jsRuntime = jsRuntime;
            _http = http;
        }

        public async Task GuardarRepertorioAsync(List<CancionModel> canciones)
        {
            await _http.PutAsJsonAsync($"{FirebaseUrl}repertorio.json", canciones);
        }

        public async Task<List<CancionModel>> ObtenerRepertorioAsync()
        {
            try 
            {
                var data = await _http.GetFromJsonAsync<List<CancionModel>>($"{FirebaseUrl}repertorio.json");
                return data ?? new List<CancionModel>();
            } 
            catch { return new List<CancionModel>(); }
        }

        public async Task GuardarSetlistsAsync(List<SetlistModel> setlists)
        {
            await _http.PutAsJsonAsync($"{FirebaseUrl}setlists.json", setlists);
        }

        public async Task<List<SetlistModel>> ObtenerSetlistsAsync()
        {
            try 
            {
                var data = await _http.GetFromJsonAsync<List<SetlistModel>>($"{FirebaseUrl}setlists.json");
                return data ?? new List<SetlistModel>();
            } 
            catch { return new List<SetlistModel>(); }
        }
    }
}
