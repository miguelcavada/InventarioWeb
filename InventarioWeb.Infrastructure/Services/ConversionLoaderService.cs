using System.Text.Json;
using System.Text.Json.Serialization;
using InventarioWeb.Core.Entities;
using InventarioWeb.Core.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace InventarioWeb.Infrastructure.Services;

public interface IConversionLoaderService
{
    Task CargarConversionesDesdeJsonAsync();
}

public class ConversionLoaderService : IConversionLoaderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHostEnvironment _env;
    private readonly ILogger<ConversionLoaderService> _logger;

    public ConversionLoaderService(IUnitOfWork unitOfWork, IHostEnvironment env, ILogger<ConversionLoaderService> logger)
    {
        _unitOfWork = unitOfWork;
        _env = env;
        _logger = logger;
    }

    public async Task CargarConversionesDesdeJsonAsync()
    {
        var filePath = Path.Combine(_env.ContentRootPath, "wwwroot", "data", "conversiones.json");

        if (!File.Exists(filePath))
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", "conversiones.json");
        }

        if (!File.Exists(filePath))
        {
            _logger.LogWarning("Archivo no encontrado");
            return;
        }

        var json = await File.ReadAllTextAsync(filePath);
        _logger.LogInformation("JSON leído: {Length} caracteres", json.Length);

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var data = JsonSerializer.Deserialize<ConversionesJsonData>(json, options);

        _logger.LogInformation("Conversiones en JSON: {Count}", data?.Conversiones?.Count ?? 0);

        if (data?.Conversiones == null || !data.Conversiones.Any())
            return;

        var unidades = (await _unitOfWork.UnidadesMedida.GetAllAsync()).ToList();
        _logger.LogInformation("Unidades en BD: {Count}", unidades.Count);

        foreach (var u in unidades)
        {
            _logger.LogInformation("Unidad: Id={Id}, Nombre={Nombre}, Abrev={Abrev}", u.Id, u.Nombre, u.Abreviatura);
        }

        int creadas = 0;
        int omitidas = 0;
        int noEncontradas = 0;

        foreach (var conv in data.Conversiones)
        {
            _logger.LogInformation("Procesando: {Origen} -> {Destino} = {Factor}", conv.Origen, conv.Destino, conv.Factor);

            var unidadOrigen = unidades.FirstOrDefault(u =>
                u.Abreviatura.Equals(conv.Origen, StringComparison.OrdinalIgnoreCase));
            var unidadDestino = unidades.FirstOrDefault(u =>
                u.Abreviatura.Equals(conv.Destino, StringComparison.OrdinalIgnoreCase));

            if (unidadOrigen == null)
            {
                _logger.LogWarning("Unidad origen no encontrada: {Origen}", conv.Origen);
                noEncontradas++;
                continue;
            }

            if (unidadDestino == null)
            {
                _logger.LogWarning("Unidad destino no encontrada: {Destino}", conv.Destino);
                noEncontradas++;
                continue;
            }

            _logger.LogInformation("Unidades encontradas: OrigenId={OrigenId}, DestinoId={DestinoId}",
                unidadOrigen.Id, unidadDestino.Id);

            var existe = await _unitOfWork.Conversiones.GetConversionAsync(unidadOrigen.Id, unidadDestino.Id);

            if (existe != null)
            {
                _logger.LogInformation("Ya existe conversión: Id={Id}", existe.Id);
                omitidas++;
                continue;
            }

            var nuevaConversion = new ConversionUnidad
            {
                UnidadOrigenId = unidadOrigen.Id,
                UnidadDestinoId = unidadDestino.Id,
                Factor = (decimal)conv.Factor,
                Descripcion = conv.Descripcion,
                Activo = true,
                FechaCreacion = DateTime.Now
            };

            await _unitOfWork.Conversiones.AddAsync(nuevaConversion);
            creadas++;
            _logger.LogInformation("Creada conversión: {Origen} -> {Destino}", conv.Origen, conv.Destino);
        }

        _logger.LogInformation("Resumen: Creadas={Creadas}, Omitidas={Omitidas}, NoEncontradas={NoEncontradas}",
            creadas, omitidas, noEncontradas);

        if (creadas > 0)
        {
            await _unitOfWork.CompleteAsync();
            _logger.LogInformation("Guardado en base de datos");
        }
    }
}

public class ConversionesJsonData
{
    [JsonPropertyName("conversiones")]
    public List<ConversionJsonItem> Conversiones { get; set; } = new();
}

public class ConversionJsonItem
{
    [JsonPropertyName("origen")]
    public string Origen { get; set; } = string.Empty;

    [JsonPropertyName("destino")]
    public string Destino { get; set; } = string.Empty;

    [JsonPropertyName("factor")]
    public double Factor { get; set; }

    [JsonPropertyName("descripcion")]
    public string? Descripcion { get; set; }
}