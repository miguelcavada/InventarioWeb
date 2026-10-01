using Blazored.Toast;
using InventarioWeb.Blazor.Services;
using InventarioWeb.BlazorApp;
using InventarioWeb.BlazorApp.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Configurar HttpClient apuntando a la API
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:5007") // Puerto de la API
});

// Servicios Blazored
builder.Services.AddBlazoredToast();

// Servicios de API
builder.Services.AddScoped<IProductoApiService, ProductoApiService>();
builder.Services.AddScoped<ICategoriaApiService, CategoriaApiService>();
builder.Services.AddScoped<IAlmacenApiService, AlmacenApiService>();
builder.Services.AddScoped<IMovimientoApiService, MovimientoApiService>();
builder.Services.AddScoped<IDashboardApiService, DashboardApiService>();

await builder.Build().RunAsync();
