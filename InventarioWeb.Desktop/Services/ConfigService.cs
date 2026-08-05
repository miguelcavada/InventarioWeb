using InventarioWeb.Desktop.Data;
using Microsoft.EntityFrameworkCore;

namespace InventarioWeb.Desktop.Services;

public interface IConfigService
{
    Task<string?> GetAsync(string clave);
    Task SetAsync(string clave, string valor);
    Task<string> GetApiUrlAsync();
    Task SetApiUrlAsync(string url);
}

public class ConfigService : IConfigService
{
    public async Task<string?> GetAsync(string clave)
    {
        using var db = new LocalDbContext();
        var config = await db.Configuraciones.FirstOrDefaultAsync(c => c.Clave == clave);
        return config?.Valor;
    }

    public async Task SetAsync(string clave, string valor)
    {
        using var db = new LocalDbContext();
        var config = await db.Configuraciones.FirstOrDefaultAsync(c => c.Clave == clave);

        if (config == null)
        {
            db.Configuraciones.Add(new AppConfig { Clave = clave, Valor = valor });
        }
        else
        {
            config.Valor = valor;
        }

        await db.SaveChangesAsync();
    }

    public async Task<string> GetApiUrlAsync()
    {
        return await GetAsync("ApiUrl") ?? "https://localhost:5001/api/";
    }

    public async Task SetApiUrlAsync(string url)
    {
        await SetAsync("ApiUrl", url);
    }
}