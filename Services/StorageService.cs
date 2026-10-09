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
        private readonly IJSRuntime _jsRuntime;
        private readonly HttpClient _http;
        private const string RepertorioKey = "repertorio_ddmchords";
        private const string SetlistsKey = "setlists_ddmchords";

        public StorageService(IJSRuntime jsRuntime, HttpClient http)
        {
            _jsRuntime = jsRuntime;
            _http = http;
        }

        public async Task GuardarRepertorioAsync(List<CancionModel> canciones)
        {
            var json = JsonSerializer.Serialize(canciones);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", RepertorioKey, json);
        }

        public async Task<List<CancionModel>> ObtenerRepertorioAsync()
        {
            var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", RepertorioKey);
            
            if (!string.IsNullOrEmpty(json))
            {
                var localData = JsonSerializer.Deserialize<List<CancionModel>>(json);
                if (localData != null && localData.Count > 0) return localData;
            }
            return new List<CancionModel>();
        }

        public async Task GuardarSetlistsAsync(List<SetlistModel> setlists)
        {
            var json = JsonSerializer.Serialize(setlists);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", SetlistsKey, json);
        }

        public async Task<List<SetlistModel>> ObtenerSetlistsAsync()
        {
            var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", SetlistsKey);
            if (!string.IsNullOrEmpty(json))
            {
                var localData = JsonSerializer.Deserialize<List<SetlistModel>>(json);
                if (localData != null) return localData;
            }
            return new List<SetlistModel>();
        }
    }
}
