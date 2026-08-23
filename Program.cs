using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using DDMChords;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Configuramos las raíces del enrutador de Blazor
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Proveemos el servicio de HttpClient para futuras conexiones a APIs
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();