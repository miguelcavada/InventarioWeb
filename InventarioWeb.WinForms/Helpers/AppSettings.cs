using System;
using System.IO;
using System.Text.Json;

namespace InventarioWeb.WinForms.Helpers;

public class AppSettings
{
    public bool MenuColapsado { get; set; } = false;

    private static readonly string RutaArchivo = Path.Combine(
        AppDomain.CurrentDomain.BaseDirectory,
        "appsettings.user.json");

    public static AppSettings Cargar()
    {
        try
        {
            if (File.Exists(RutaArchivo))
            {
                var json = File.ReadAllText(RutaArchivo);
                var settings = JsonSerializer.Deserialize<AppSettings>(json);
                return settings ?? new AppSettings();
            }
        }
        catch
        {
            // Ignorar errores
        }
        return new AppSettings();
    }

    public void Guardar()
    {
        try
        {
            var json = JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(RutaArchivo, json);
        }
        catch
        {
            // Ignorar errores
        }
    }
}